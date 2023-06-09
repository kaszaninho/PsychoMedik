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
    public class PacjentController : ControllerBase
    {
        private readonly PsychoMedikDatabase _context;

        public PacjentController(PsychoMedikDatabase context)
        {
            _context = context;
        }

        // GET: api/Pacjent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pacjent>>> GetPacjent()
        {
          if (_context.Pacjent == null)
          {
              return NotFound();
          }
            return await _context.Pacjent.ToListAsync();
        }

        // GET: api/Pacjent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pacjent>> GetPacjent(int id)
        {
          if (_context.Pacjent == null)
          {
              return NotFound();
          }
            var pacjent = await _context.Pacjent.FindAsync(id);

            if (pacjent == null)
            {
                return NotFound();
            }

            return pacjent;
        }

        // PUT: api/Pacjent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacjent(int id, Pacjent pacjent)
        {
            if (id != pacjent.Id)
            {
                return BadRequest();
            }

            _context.Entry(pacjent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacjentExists(id))
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

        // POST: api/Pacjent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pacjent>> PostPacjent(Pacjent pacjent)
        {
          if (_context.Pacjent == null)
          {
              return Problem("Entity set 'PsychoMedikDatabase.Pacjent'  is null.");
          }
            _context.Pacjent.Add(pacjent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPacjent", new { id = pacjent.Id }, pacjent);
        }

        // DELETE: api/Pacjent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacjent(int id)
        {
            if (_context.Pacjent == null)
            {
                return NotFound();
            }
            var pacjent = await _context.Pacjent.FindAsync(id);
            if (pacjent == null)
            {
                return NotFound();
            }

            _context.Pacjent.Remove(pacjent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacjentExists(int id)
        {
            return (_context.Pacjent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
