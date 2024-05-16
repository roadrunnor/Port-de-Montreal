namespace PortAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PortAPI.Data;
    using PortAPI.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class DeparturesController : ControllerBase
    {
        private readonly PortDbContext _context;

        public DeparturesController(PortDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipDeparture>>> GetDeparts()
        {
            return await _context.Departs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShipDeparture>> GetDepart(int id)
        {
            var depart = await _context.Departs.FindAsync(id);
            if (depart == null)
            {
                return NotFound();
            }
            return depart;
        }

        [HttpPost]
        public async Task<ActionResult<ShipDeparture>> PostDepart(ShipDeparture depart)
        {
            _context.Departs.Add(depart);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDepart), new { id = depart.Id }, depart);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepart(int id, ShipDeparture depart)
        {
            if (id != depart.Id)
            {
                return BadRequest();
            }

            _context.Entry(depart).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Departs.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteDepart(int id)
        {
            var depart = await _context.Departs.FindAsync(id);
            if (depart == null)
            {
                return NotFound();
            }

            _context.Departs.Remove(depart);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
