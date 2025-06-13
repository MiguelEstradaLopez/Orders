using Microsoft.AspNetCore.Mvc; // Importa las clases de MVC
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Shared.Entities;

namespace Orders.Backend.Controllers
{
    [ApiController] // Indica que es un controlador de API
    [Route("api/[controller]")] // Define la ruta base para el controlador
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context; // Inyecta el contexto de la base de datos

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // Maneja solicitudes GET a la ruta base
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _context.Countries.ToListAsync()); // Devuelve todos los países
        }

        [HttpGet("{id}")] // Maneja solicitudes GET con un ID en la ruta
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id); // Busca un país por ID
            if (country == null)
            {
                return NotFound(); // Si no se encuentra, devuelve 404
            }
            return Ok(country); // Devuelve el país encontrado
        }

        [HttpPost] // Maneja solicitudes POST (creación)
        public async Task<IActionResult> PostAsync(Country country)
        {
            _context.Add(country); // Agrega el nuevo país
            await _context.SaveChangesAsync(); // Guarda los cambios en la BD
            return Ok(country); // Devuelve el país creado
        }

        [HttpDelete("{id}")] // Maneja solicitudes DELETE con un ID en la ruta
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == id); // Busca el país a eliminar
            if (country == null)
            {
                return NotFound(); // Si no se encuentra, devuelve 404
            }

            _context.Remove(country); // Elimina el país
            await _context.SaveChangesAsync();
            return NoContent(); // Devuelve 204 (sin contenido)
        }

        [HttpPut] // Maneja solicitudes PUT (actualización)
        public async Task<IActionResult> PutAsync(Country country)
        {
            _context.Update(country); // Actualiza el país
            await _context.SaveChangesAsync();
            return Ok(country); // Devuelve el país actualizado
        }
    }
}