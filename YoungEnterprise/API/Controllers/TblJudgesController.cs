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
    [Route("api/TblJudges")]
    [EnableCors("AllowSpecificOrigin")]
    public class TblJudgesController : Controller
    {
        private readonly DB_YoungEnterpriseContext _context;

        public TblJudgesController(DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        // GET: api/TblJudges
        [HttpGet]
        public IEnumerable<TblJudge> GetTblJudge()
        {
            return _context.TblJudge;
        }

        // GET: api/TblJudges/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblJudge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblJudge = await _context.TblJudge.SingleOrDefaultAsync(m => m.FldJudgeId == id);

            if (tblJudge == null)
            {
                return NotFound();
            }

            return Ok(tblJudge);
        }

        // PUT: api/TblJudges/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblJudge([FromRoute] int id, [FromBody] TblJudge tblJudge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblJudge.FldJudgeId)
            {
                return BadRequest();
            }

            _context.Entry(tblJudge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblJudgeExists(id))
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

        // POST: api/TblJudges
        [HttpPost]
        public async Task<IActionResult> PostTblJudge([FromBody] TblJudge tblJudge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblJudge.Add(tblJudge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblJudge", new { id = tblJudge.FldJudgeId }, tblJudge);
        }

        // DELETE: api/TblJudges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblJudge([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblJudge = await _context.TblJudge.SingleOrDefaultAsync(m => m.FldJudgeId == id);
            if (tblJudge == null)
            {
                return NotFound();
            }

            _context.TblJudge.Remove(tblJudge);
            await _context.SaveChangesAsync();

            return Ok(tblJudge);
        }

        private bool TblJudgeExists(int id)
        {
            return _context.TblJudge.Any(e => e.FldJudgeId == id);
        }
    }
}