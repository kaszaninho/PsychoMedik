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
    public class WizytaController : ControllerBase
    {
        private readonly PsychoMedikDatabase _context;

        public WizytaController(PsychoMedikDatabase context)
        {
            _context = context;
        }

        // GET: api/Wizyta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wizyta>>> GetWizyta()
        {
          if (_context.Wizyta == null)
          {
              return NotFound();
          }
            return await _context.Wizyta.ToListAsync();
        }

        // GET: api/Wizyta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wizyta>> GetWizyta(int id)
        {
          if (_context.Wizyta == null)
          {
              return NotFound();
          }
            var wizyta = await _context.Wizyta.FindAsync(id);

            if (wizyta == null)
            {
                return NotFound();
            }

            return wizyta;
        }

        // PUT: api/Wizyta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWizyta(int id, Wizyta wizyta)
        {
            if (id != wizyta.Id)
            {
                return BadRequest();
            }

            _context.Entry(wizyta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WizytaExists(id))
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

        // POST: api/Wizyta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wizyta>> PostWizyta(Wizyta wizyta)
        {
          if (_context.Wizyta == null)
          {
              return Problem("Entity set 'PsychoMedikDatabase.Wizyta'  is null.");
          }
            _context.Wizyta.Add(wizyta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWizyta", new { id = wizyta.Id }, wizyta);
        }

        // DELETE: api/Wizyta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWizyta(int id)
        {
            if (_context.Wizyta == null)
            {
                return NotFound();
            }
            var wizyta = await _context.Wizyta.FindAsync(id);
            if (wizyta == null)
            {
                return NotFound();
            }

            _context.Wizyta.Remove(wizyta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WizytaExists(int id)
        {
            return (_context.Wizyta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
