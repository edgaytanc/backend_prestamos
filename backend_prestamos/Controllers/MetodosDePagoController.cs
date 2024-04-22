using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend_prestamos.Data;
using backend_prestamos.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace backend_prestamos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodosDePagoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MetodosDePagoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MetodosDePago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetodoDePago>>> GetMetodosDePago()
        {
            return await _context.MetodosDePagos.ToListAsync();
        }

        // GET: api/MetodosDePago/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetodoDePago>> GetMetodoDePago(int id)
        {
            var metodoDePago = await _context.MetodosDePagos.FindAsync(id);

            if (metodoDePago == null)
            {
                return NotFound();
            }

            return metodoDePago;
        }

        // POST: api/MetodosDePago
        [HttpPost]
        public async Task<ActionResult<MetodoDePago>> PostMetodoDePago(MetodoDePago metodoDePago)
        {
            _context.MetodosDePagos.Add(metodoDePago);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetodoDePago", new { id = metodoDePago.IdPago }, metodoDePago);
        }

        // PUT: api/MetodosDePago/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodoDePago(int id, MetodoDePago metodoDePago)
        {
            if (id != metodoDePago.IdPago)
            {
                return BadRequest();
            }

            _context.Entry(metodoDePago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetodoDePagoExists(id))
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

        // DELETE: api/MetodosDePago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodoDePago(int id)
        {
            var metodoDePago = await _context.MetodosDePagos.FindAsync(id);
            if (metodoDePago == null)
            {
                return NotFound();
            }

            _context.MetodosDePagos.Remove(metodoDePago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método para probar la conexión a la base de datos
        [HttpGet("TestDatabaseConnection")]
        public async Task<ActionResult<string>> TestDatabaseConnection()
        {
            try
            {
                var user = await _context.MetodosDePagos.FirstOrDefaultAsync();
                return user != null ? Ok("Conexión a la base de datos verificada con éxito.") : Ok("Conexión a la base de datos verificada, pero no se encontraron préstamos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        private bool MetodoDePagoExists(int id)
        {
            return _context.MetodosDePagos.Any(e => e.IdPago == id);
        }
    }
}

