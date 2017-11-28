using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YoungEnterprise_API.Models;
using Microsoft.AspNetCore.Cors;

namespace YoungEnterprise_API.Controllers
{
    [Produces("application/json")]
    [Route("api/TblEvents")]
    [EnableCors("AllowSpecificOrigin")]
    public class TblEventsController : Controller
    {
        private readonly DB_YoungEnterpriseContext _context;

        public TblEventsController(DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        // GET: api/TblEvents
        [HttpGet]
        public IEnumerable<TblEvent> GetTblEvent()
        {
            return _context.TblEvent;
        }

        // GET: api/TblEvents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblEvent = await _context.TblEvent.SingleOrDefaultAsync(m => m.FldEventId == id);

            if (tblEvent == null)
            {
                return NotFound();
            }

            return Ok(tblEvent);
        }

        // PUT: api/TblEvents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEvent([FromRoute] int id, [FromBody] TblEvent tblEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblEvent.FldEventId)
            {
                return BadRequest();
            }

            _context.Entry(tblEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEventExists(id))
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

        // POST: api/TblEvents
        [HttpPost]
        public async Task<IActionResult> PostTblEvent([FromBody] TblEvent tblEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblEvent.Add(tblEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEvent", new { id = tblEvent.FldEventId }, tblEvent);
        }

        // DELETE: api/TblEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblEvent = await _context.TblEvent.SingleOrDefaultAsync(m => m.FldEventId == id);
            if (tblEvent == null)
            {
                return NotFound();
            }

            _context.TblEvent.Remove(tblEvent);
            await _context.SaveChangesAsync();

            return Ok(tblEvent);
        }

        private bool TblEventExists(int id)
        {
            return _context.TblEvent.Any(e => e.FldEventId == id);
        }
    }
}