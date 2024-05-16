namespace PortAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PortAPI.Data;
    using PortAPI.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ArrivalsController : ControllerBase
    {
        private readonly PortDbContext _context;

        public ArrivalsController(PortDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipArrival>>> GetArrivees()
        {
            return await _context.Arrivees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShipArrival>> GetArrivee(int id)
        {
            var arrivee = await _context.Arrivees.FindAsync(id);
            if (arrivee == null)
            {
                return NotFound();
            }
            return arrivee;
        }

        [HttpPost]
        public async Task<ActionResult<ShipArrival>> PostArrivee(ShipArrival arrivee)
        {
            _context.Arrivees.Add(arrivee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArrivee), new { id = arrivee.Id }, arrivee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrivee(int id, ShipArrival arrivee)
        {
            if (id != arrivee.Id)
            {
                return BadRequest();
            }

            _context.Entry(arrivee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Arrivees.Any(e => e.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrivee(int id)
        {
            var arrivee = await _context.Arrivees.FindAsync(id);
            if (arrivee == null)
            {
                return NotFound();
            }

            _context.Arrivees.Remove(arrivee);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
