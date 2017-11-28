using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoungEnterprise_API.Models;
using Microsoft.AspNetCore.Cors;

namespace YoungEnterprise_API.Controllers
{
    [Produces("application/json")]
    [Route("api/TblQuestions")]
    [EnableCors("AllowSpecificOrigin")]
    public class TblQuestionsController : Controller
    {
        private readonly DB_YoungEnterpriseContext _context;

        public TblQuestionsController(DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        // GET: api/TblQuestions
        [HttpGet]
        public IEnumerable<TblQuestion> GetTblQuestion()
        {
            return _context.TblQuestion;
        }

        // GET: api/TblQuestions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblQuestion = await _context.TblQuestion.SingleOrDefaultAsync(m => m.FldQuestionId == id);

            if (tblQuestion == null)
            {
                return NotFound();
            }

            return Ok(tblQuestion);
        }

        // PUT: api/TblQuestions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblQuestion([FromRoute] int id, [FromBody] TblQuestion tblQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblQuestion.FldQuestionId)
            {
                return BadRequest();
            }

            _context.Entry(tblQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TblQuestions
        [HttpPost]
        public async Task<IActionResult> PostTblQuestion([FromBody] TblQuestion tblQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblQuestion.Add(tblQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblQuestion", new { id = tblQuestion.FldQuestionId }, tblQuestion);
        }

        // DELETE: api/TblQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblQuestion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblQuestion = await _context.TblQuestion.SingleOrDefaultAsync(m => m.FldQuestionId == id);
            if (tblQuestion == null)
            {
                return NotFound();
            }

            _context.TblQuestion.Remove(tblQuestion);
            await _context.SaveChangesAsync();

            return Ok(tblQuestion);
        }

        private bool TblQuestionExists(int id)
        {
            return _context.TblQuestion.Any(e => e.FldQuestionId == id);
        }
    }
}