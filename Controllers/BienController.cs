using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalidadTPApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMunicipalidadTP.Models;

namespace MunicipalidadTPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BienController : ControllerBase
    {
        private readonly MunicipalidadContext _context;

        public BienController(MunicipalidadContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bien>>> GetBienes()
        {
            return await _context.Bienes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bien>> GetBien(int id)
        {
            var bien = await _context.Bienes.FindAsync(id);

            if (bien == null)
            {
                return NotFound();
            }

            return bien;
        }

        [HttpPost]
        public async Task<ActionResult<Bien>> PostBien(Bien bien)
        {
            _context.Bienes.Add(bien);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBien), new { id = bien.Idbien }, bien);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBien(int id, Bien bien)
        {
            if (id != bien.Idbien)
            {
                return BadRequest();
            }

            _context.Entry(bien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BienExists(id))
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
        public async Task<IActionResult> DeleteBien(int id)
        {
            var bien = await _context.Bienes.FindAsync(id);
            if (bien == null)
            {
                return NotFound();
            }

            _context.Bienes.Remove(bien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BienExists(int id)
        {
            return _context.Bienes.Any(e => e.Idbien == id);
        }
    }
}
