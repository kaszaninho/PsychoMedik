using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoMedikAPI.Data;
using PsychoMedikAPI.Models;

namespace PsychoMedikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaChorobyController : ControllerBase
    {
        private readonly PsychoMedikDatabase _context;

        public HistoriaChorobyController(PsychoMedikDatabase context)
        {
            _context = context;
        }

        // GET: api/HistoriaChoroby
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoriaChoroby>>> GetHistoriaChoroby()
        {
          if (_context.HistoriaChoroby == null)
          {
              return NotFound();
          }
            return await _context.HistoriaChoroby.ToListAsync();
        }

        // GET: api/HistoriaChoroby/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoriaChoroby>> GetHistoriaChoroby(int id)
        {
          if (_context.HistoriaChoroby == null)
          {
              return NotFound();
          }
            var historiaChoroby = await _context.HistoriaChoroby.FindAsync(id);

            if (historiaChoroby == null)
            {
                return NotFound();
            }

            return historiaChoroby;
        }

        // PUT: api/HistoriaChoroby/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoriaChoroby(int id, HistoriaChoroby historiaChoroby)
        {
            if (id != historiaChoroby.Id)
            {
                return BadRequest();
            }

            _context.Entry(historiaChoroby).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaChorobyExists(id))
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

        // POST: api/HistoriaChoroby
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoriaChoroby>> PostHistoriaChoroby(HistoriaChoroby historiaChoroby)
        {
          if (_context.HistoriaChoroby == null)
          {
              return Problem("Entity set 'PsychoMedikDatabase.HistoriaChoroby'  is null.");
          }
            _context.HistoriaChoroby.Add(historiaChoroby);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoriaChoroby", new { id = historiaChoroby.Id }, historiaChoroby);
        }

        // DELETE: api/HistoriaChoroby/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoriaChoroby(int id)
        {
            if (_context.HistoriaChoroby == null)
            {
                return NotFound();
            }
            var historiaChoroby = await _context.HistoriaChoroby.FindAsync(id);
            if (historiaChoroby == null)
            {
                return NotFound();
            }

            _context.HistoriaChoroby.Remove(historiaChoroby);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoriaChorobyExists(int id)
        {
            return (_context.HistoriaChoroby?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
