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
    [Route("api/TblVotes")]
    [EnableCors("AllowSpecificOrigin")]
    public class TblVotesController : Controller
    {
        private readonly DB_YoungEnterpriseContext _context;

        public TblVotesController(DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        // GET: api/TblVotes
        [HttpGet]
        public IEnumerable<TblVote> GetTblVote()
        {
            return _context.TblVote;
        }

        // GET: api/TblVotes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblVote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblVote = await _context.TblVote.SingleOrDefaultAsync(m => m.FldVoteId == id);

            if (tblVote == null)
            {
                return NotFound();
            }

            return Ok(tblVote);
        }

        // PUT: api/TblVotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblVote([FromRoute] int id, [FromBody] TblVote tblVote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblVote.FldVoteId)
            {
                return BadRequest();
            }

            _context.Entry(tblVote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblVoteExists(id))
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

        // POST: api/TblVotes
        [HttpPost]
        public async Task<IActionResult> PostTblVote([FromBody] TblVote tblVote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblVote.Add(tblVote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblVote", new { id = tblVote.FldVoteId }, tblVote);
        }

        // DELETE: api/TblVotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblVote([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblVote = await _context.TblVote.SingleOrDefaultAsync(m => m.FldVoteId == id);
            if (tblVote == null)
            {
                return NotFound();
            }

            _context.TblVote.Remove(tblVote);
            await _context.SaveChangesAsync();

            return Ok(tblVote);
        }

        private bool TblVoteExists(int id)
        {
            return _context.TblVote.Any(e => e.FldVoteId == id);
        }
    }
}