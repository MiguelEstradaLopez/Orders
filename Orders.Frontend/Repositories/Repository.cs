using System.Text;
using System.Text.Json; // Importa las clases para serialización JSON

namespace Orders.Frontend.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient; // Cliente HTTP para hacer solicitudes
        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, // Configuración para ignorar mayúsculas/minúsculas en JSON
        };

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url); // Hace una solicitud GET
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<T>(responseHttp); // Deserializa la respuesta
                return new HttpResponseWrapper<T>(response, false, responseHttp);
            }
            return new HttpResponseWrapper<T>(default, true, responseHttp); // Retorna un error si la solicitud no fue exitosa
        }

        public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model); // Serializa el modelo a JSON
            var messageContet = new StringContent(messageJSON, Encoding.UTF8, "application/json"); // Crea el contenido HTTP
            var responseHttp = await _httpClient.PostAsync(url, messageContet); // Hace una solicitud POST
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp); // Retorna la respuesta
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContet = new StringContent(messageJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, messageContet);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<TActionResponse>(responseHttp);
                return new HttpResponseWrapper<TActionResponse>(response, false, responseHttp);
            }
            return new HttpResponseWrapper<TActionResponse>(default, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        // Método para deserializar la respuesta HTTP
        private async Task<T> UnserializeAnswer<T>(HttpResponseMessage responseHttp)
        {
            var response = await responseHttp.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(response, _jsonDefaultOptions)!; // Deserializa el JSON a un objeto T
        }
    }
}