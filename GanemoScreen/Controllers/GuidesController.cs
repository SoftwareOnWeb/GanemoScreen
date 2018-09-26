using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GanemoScreen.EF;
using GanemoScreen.Model;

namespace GanemoScreen.Controllers
{
    [Produces("application/json")]
    [Route("api/Guides")]
    public class GuidesController : Controller
    {
        private readonly EFContext _context;

        public GuidesController(EFContext context)
        {
            _context = context;
        }

        // GET: api/Guides
        [HttpGet]
        public IEnumerable<Guide> GetGuides()
        {
            return _context.Guides;
        }

        // GET: api/Guides/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuide([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guide = await _context.Guides.SingleOrDefaultAsync(m => m.Id == id);

            if (guide == null)
            {
                return NotFound();
            }

            return Ok(guide);
        }

        // PUT: api/Guides/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuide([FromRoute] int id, [FromBody] Guide guide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != guide.Id)
            {
                return BadRequest();
            }

            _context.Entry(guide).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuideExists(id))
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

        // POST: api/Guides
        [HttpPost]
        public async Task<IActionResult> PostGuide([FromBody] Guide guide)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Guides.Add(guide);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuide", new { id = guide.Id }, guide);
        }

        // DELETE: api/Guides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuide([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var guide = await _context.Guides.SingleOrDefaultAsync(m => m.Id == id);
            if (guide == null)
            {
                return NotFound();
            }

            _context.Guides.Remove(guide);
            await _context.SaveChangesAsync();

            return Ok(guide);
        }

        private bool GuideExists(int id)
        {
            return _context.Guides.Any(e => e.Id == id);
        }
    }
}