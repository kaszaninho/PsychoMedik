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
    public class PracownikController : ControllerBase
    {
        private readonly PsychoMedikDatabase _context;

        public PracownikController(PsychoMedikDatabase context)
        {
            _context = context;
        }

        // GET: api/Pracownik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pracownik>>> GetPracownik()
        {
          if (_context.Pracownik == null)
          {
              return NotFound();
          }
            return await _context.Pracownik.ToListAsync();
        }

        // GET: api/Pracownik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pracownik>> GetPracownik(int id)
        {
          if (_context.Pracownik == null)
          {
              return NotFound();
          }
            var pracownik = await _context.Pracownik.FindAsync(id);

            if (pracownik == null)
            {
                return NotFound();
            }

            return pracownik;
        }

        // PUT: api/Pracownik/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPracownik(int id, Pracownik pracownik)
        {
            if (id != pracownik.Id)
            {
                return BadRequest();
            }

            _context.Entry(pracownik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracownikExists(id))
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

        // POST: api/Pracownik
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pracownik>> PostPracownik(Pracownik pracownik)
        {
          if (_context.Pracownik == null)
          {
              return Problem("Entity set 'PsychoMedikDatabase.Pracownik'  is null.");
          }
            _context.Pracownik.Add(pracownik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPracownik", new { id = pracownik.Id }, pracownik);
        }

        // DELETE: api/Pracownik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePracownik(int id)
        {
            if (_context.Pracownik == null)
            {
                return NotFound();
            }
            var pracownik = await _context.Pracownik.FindAsync(id);
            if (pracownik == null)
            {
                return NotFound();
            }

            _context.Pracownik.Remove(pracownik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PracownikExists(int id)
        {
            return (_context.Pracownik?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
