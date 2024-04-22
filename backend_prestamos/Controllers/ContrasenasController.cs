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
    public class ContrasenasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContrasenasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Contraseñas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contrasena>>> GetContraseñas()
        {
            return await _context.Contrasenas.ToListAsync();
        }

        // GET: api/Contraseñas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrasena>> GetContrasena(int id)
        {
            var contrasena = await _context.Contrasenas.FindAsync(id);

            if (contrasena == null)
            {
                return NotFound();
            }

            return contrasena;
        }

        // POST: api/Contraseñas
        [HttpPost]
        public async Task<ActionResult<Contrasena>> PostContrasena(Contrasena contrasena)
        {
            _context.Contrasenas.Add(contrasena);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContrasena), new { id = contrasena.IdContrasena }, contrasena);
        }

        // PUT: api/Contraseñas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContrasena(int id, Contrasena contrasena)
        {
            if (id != contrasena.IdContrasena)
            {
                return BadRequest();
            }

            _context.Entry(contrasena).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContrasenaExists(id))
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

        // DELETE: api/Contraseñas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContrasena(int id)
        {
            var contrasena = await _context.Contrasenas.FindAsync(id);
            if (contrasena == null)
            {
                return NotFound();
            }

            _context.Contrasenas.Remove(contrasena);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Método para probar la conexión a la base de datos
        [HttpGet("TestDatabaseConnection")]
        public async Task<ActionResult<string>> TestDatabaseConnection()
        {
            try
            {
                var user = await _context.Contrasenas.FirstOrDefaultAsync();
                return user != null ? Ok("Conexión a la base de datos verificada con éxito.") : Ok("Conexión a la base de datos verificada, pero no se encontraron préstamos.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al conectar a la base de datos: {ex.Message}");
            }
        }

        private bool ContrasenaExists(int id)
        {
            return _context.Contrasenas.Any(e => e.IdContrasena == id);
        }
    }
}

