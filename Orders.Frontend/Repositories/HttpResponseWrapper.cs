using System.Net; // Importa las clases de red

namespace Orders.Frontend.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response; // La respuesta real del servidor
            Error = error; // Indica si hubo un error
            HttpResponseMessage = httpResponseMessage; // El mensaje HTTP completo
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null; // No hay error, no hay mensaje
            }

            var statusCode = HttpResponseMessage.StatusCode; // Obtiene el código de estado HTTP
            if (statusCode == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado.";
            }
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync(); // Lee el mensaje de error del contenido
            }
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Tienes que estar logueado para ejecutar esta operación.";
            }
            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos para hacer esta operación.";
            }

            return "Ha ocurrido un error inesperado."; // Mensaje genérico para otros errores
        }
    }
}