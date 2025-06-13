using Microsoft.AspNetCore.Mvc; // Importa las clases de MVC (para atributos como ApiController y Route)
using Orders.Backend.UnitsOfWork.Interfaces; // Necesario para IGenericUnitOfWork
using Orders.Shared.Entities; // Necesario para la entidad Country

namespace Orders.Backend.Controllers
{
    [ApiController] // Indica que es un controlador de API
    [Route("api/[controller]")] // Define la ruta base para el controlador
    // Ahora hereda del controlador genérico, delegando las operaciones CRUD básicas a GenericController
    public class CountriesController : GenericController<Country>
    {
        // El constructor ahora recibe una instancia de IGenericUnitOfWork<Country>
        // y la pasa al constructor de la clase base (GenericController).
        public CountriesController(IGenericUnitOfWork<Country> unit) : base(unit)
        {
        }
        // Todos los métodos CRUD (Get, Post, Put, Delete) y el DataContext privado
        // se han eliminado de aquí porque ahora son manejados por GenericController.
        // Solo necesitas el constructor para pasar la unidad de trabajo genérica.
    }
}