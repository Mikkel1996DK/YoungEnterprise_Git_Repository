using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoungEnterprise_API.Models;
using Microsoft.AspNetCore.Cors;
using Service;

namespace YoungEnterprise_API.Controllers
{
    [Produces("application/json")]
    [Route("api/TblTeams")]
    [EnableCors("AllowSpecificOrigin")]
    public class TblTeamsController : Controller
    {
        private readonly DB_YoungEnterpriseContext _context;
        private readonly VoteService voteService;

        public TblTeamsController(DB_YoungEnterpriseContext context)
        {
            _context = context; // todo remove when using services
            voteService = new VoteService(_context);
        }
        /*
        // GET: api/TblTeams
        [HttpGet]
        public IEnumerable<TblTeam> GetTblTeam()
        {
            return _context.TblTeam;
        }
        */
        // GET: api/TblTeams?NoVotesFromPair=42
        [HttpGet]
        public IEnumerable<TblTeam> GetTblTeam(int NoVotesFromPair = -1)
        {
            if (NoVotesFromPair == -1)
            {
                return _context.TblTeam;
            }
            else
            {
                return _context.TblTeam;
            }

        }

        // GET: api/TblTeams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblTeam([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblTeam = await _context.TblTeam.SingleOrDefaultAsync(m => m.FldTeamName == id);

            if (tblTeam == null)
            {
                return NotFound();
            }

            return Ok(tblTeam);
        }

        // PUT: api/TblTeams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblTeam([FromRoute] string id, [FromBody] TblTeam tblTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblTeam.FldTeamName)
            {
                return BadRequest();
            }

            _context.Entry(tblTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblTeamExists(id))
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

        // POST: api/TblTeams
        [HttpPost]
        public async Task<IActionResult> PostTblTeam([FromBody] TblTeam tblTeam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblTeam.Add(tblTeam);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblTeamExists(tblTeam.FldTeamName))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblTeam", new { id = tblTeam.FldTeamName }, tblTeam);
        }

        // DELETE: api/TblTeams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblTeam([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblTeam = await _context.TblTeam.SingleOrDefaultAsync(m => m.FldTeamName == id);
            if (tblTeam == null)
            {
                return NotFound();
            }

            _context.TblTeam.Remove(tblTeam);
            await _context.SaveChangesAsync();

            return Ok(tblTeam);
        }

        private bool TblTeamExists(string id)
        {
            return _context.TblTeam.Any(e => e.FldTeamName == id);
        }
    }
}