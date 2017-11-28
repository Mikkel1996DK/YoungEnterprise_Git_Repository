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
    [Route("api/TblJudgePairs")]
    [EnableCors("AllowSpecificOrigin")]
    public class TblJudgePairsController : Controller
    {
        private readonly DB_YoungEnterpriseContext _context;

        public TblJudgePairsController(DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        // GET: api/TblJudgePairs
        [HttpGet]
        public IEnumerable<TblJudgePair> GetTblJudgePair()
        {
            return _context.TblJudgePair;
        }

        // GET: api/TblJudgePairs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblJudgePair([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblJudgePair = await _context.TblJudgePair.SingleOrDefaultAsync(m => m.FldJudgePairId == id);

            if (tblJudgePair == null)
            {
                return NotFound();
            }

            return Ok(tblJudgePair);
        }

        // PUT: api/TblJudgePairs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblJudgePair([FromRoute] int id, [FromBody] TblJudgePair tblJudgePair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblJudgePair.FldJudgePairId)
            {
                return BadRequest();
            }

            _context.Entry(tblJudgePair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblJudgePairExists(id))
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

        // POST: api/TblJudgePairs
        [HttpPost]
        public async Task<IActionResult> PostTblJudgePair([FromBody] TblJudgePair tblJudgePair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblJudgePair.Add(tblJudgePair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblJudgePair", new { id = tblJudgePair.FldJudgePairId }, tblJudgePair);
        }

        // DELETE: api/TblJudgePairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblJudgePair([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblJudgePair = await _context.TblJudgePair.SingleOrDefaultAsync(m => m.FldJudgePairId == id);
            if (tblJudgePair == null)
            {
                return NotFound();
            }

            _context.TblJudgePair.Remove(tblJudgePair);
            await _context.SaveChangesAsync();

            return Ok(tblJudgePair);
        }

        private bool TblJudgePairExists(int id)
        {
            return _context.TblJudgePair.Any(e => e.FldJudgePairId == id);
        }
    }
}