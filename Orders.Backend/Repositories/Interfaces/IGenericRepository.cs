using Orders.Shared.Responses;

namespace Orders.Backend.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class // Restricción para que T sea una clase
    {
        Task<ActionResponse<T>> GetAsync(int id); // Obtener por ID
        Task<ActionResponse<IEnumerable<T>>> GetAsync(); // Obtener todos
        Task<ActionResponse<T>> AddAsync(T entity); // Agregar
        Task<ActionResponse<T>> DeleteAsync(int id); // Eliminar
        Task<ActionResponse<T>> UpdateAsync(T entity); // Actualizar
    }
}