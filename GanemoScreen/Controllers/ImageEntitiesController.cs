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
    [Route("api/ImageEntities")]
    public class ImageEntitiesController : Controller
    {
        private readonly EFContext _context;

        public ImageEntitiesController(EFContext context)
        {
            _context = context;
        }

        // GET: api/ImageEntities
        [HttpGet]
        public IEnumerable<ImageEntity> GetimageEntities()
        {
            return _context.imageEntities;
        }

        // GET: api/ImageEntities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imageEntity = await _context.imageEntities.SingleOrDefaultAsync(m => m.Id == id);

            if (imageEntity == null)
            {
                return NotFound();
            }

            return Ok(imageEntity);
        }

        // PUT: api/ImageEntities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageEntity([FromRoute] int id, [FromBody] ImageEntity imageEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != imageEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageEntityExists(id))
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

        // POST: api/ImageEntities
        [HttpPost]
        public async Task<IActionResult> PostImageEntity([FromBody] ImageEntity imageEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.imageEntities.Add(imageEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageEntity", new { id = imageEntity.Id }, imageEntity);
        }

        // DELETE: api/ImageEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imageEntity = await _context.imageEntities.SingleOrDefaultAsync(m => m.Id == id);
            if (imageEntity == null)
            {
                return NotFound();
            }

            _context.imageEntities.Remove(imageEntity);
            await _context.SaveChangesAsync();

            return Ok(imageEntity);
        }

        private bool ImageEntityExists(int id)
        {
            return _context.imageEntities.Any(e => e.Id == id);
        }
    }
}