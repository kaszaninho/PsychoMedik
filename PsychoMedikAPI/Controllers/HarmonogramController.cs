using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoMedikAPI.Data;
using PsychoMedikAPI.Models;

namespace PsychoMedikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarmonogramController : ControllerBase
    {
        private readonly PsychoMedikDatabase _context;

        public HarmonogramController(PsychoMedikDatabase context)
        {
            _context = context;
        }

        // GET: api/Harmonogram
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Harmonogram>>> GetHarmonogram()
        {
          if (_context.Harmonogram == null)
          {
              return NotFound();
          }
            return await _context.Harmonogram.ToListAsync();
        }

        // GET: api/Harmonogram/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Harmonogram>> GetHarmonogram(int id)
        {
          if (_context.Harmonogram == null)
          {
              return NotFound();
          }
            var harmonogram = await _context.Harmonogram.FindAsync(id);

            if (harmonogram == null)
            {
                return NotFound();
            }

            return harmonogram;
        }

        // PUT: api/Harmonogram/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHarmonogram(int id, Harmonogram harmonogram)
        {
            if (id != harmonogram.Id)
            {
                return BadRequest();
            }

            _context.Entry(harmonogram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HarmonogramExists(id))
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

        // POST: api/Harmonogram
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Harmonogram>> PostHarmonogram(Harmonogram harmonogram)
        {
          if (_context.Harmonogram == null)
          {
              return Problem("Entity set 'PsychoMedikDatabase.Harmonogram'  is null.");
          }
            _context.Harmonogram.Add(harmonogram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHarmonogram", new { id = harmonogram.Id }, harmonogram);
        }

        // DELETE: api/Harmonogram/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHarmonogram(int id)
        {
            if (_context.Harmonogram == null)
            {
                return NotFound();
            }
            var harmonogram = await _context.Harmonogram.FindAsync(id);
            if (harmonogram == null)
            {
                return NotFound();
            }

            _context.Harmonogram.Remove(harmonogram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HarmonogramExists(int id)
        {
            return (_context.Harmonogram?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
