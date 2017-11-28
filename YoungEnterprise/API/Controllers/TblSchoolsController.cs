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
    [Route("api/TblSchools")]
    [EnableCors("AllowSpecificOrigin")]
    public class TblSchoolsController : Controller
    {
        private readonly DB_YoungEnterpriseContext _context;

        public TblSchoolsController(DB_YoungEnterpriseContext context)
        {
            _context = context;
        }

        // GET: api/TblSchools
        [HttpGet]
        public IEnumerable<TblSchool> GetTblSchool()
        {
            return _context.TblSchool;
        }

        // GET: api/TblSchools/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTblSchool([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblSchool = await _context.TblSchool.SingleOrDefaultAsync(m => m.FldSchoolId == id);

            if (tblSchool == null)
            {
                return NotFound();
            }

            return Ok(tblSchool);
        }

        // PUT: api/TblSchools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblSchool([FromRoute] int id, [FromBody] TblSchool tblSchool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblSchool.FldSchoolId)
            {
                return BadRequest();
            }

            _context.Entry(tblSchool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSchoolExists(id))
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

        // POST: api/TblSchools
        [HttpPost]
        public async Task<IActionResult> PostTblSchool([FromBody] TblSchool tblSchool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TblSchool.Add(tblSchool);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblSchool", new { id = tblSchool.FldSchoolId }, tblSchool);
        }

        // DELETE: api/TblSchools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblSchool([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblSchool = await _context.TblSchool.SingleOrDefaultAsync(m => m.FldSchoolId == id);
            if (tblSchool == null)
            {
                return NotFound();
            }

            _context.TblSchool.Remove(tblSchool);
            await _context.SaveChangesAsync();

            return Ok(tblSchool);
        }

        private bool TblSchoolExists(int id)
        {
            return _context.TblSchool.Any(e => e.FldSchoolId == id);
        }
    }
}