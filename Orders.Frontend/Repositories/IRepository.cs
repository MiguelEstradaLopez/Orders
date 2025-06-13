namespace Orders.Frontend.Repositories
{
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> GetAsync<T>(string url); // Para obtener datos
        Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model); // Para enviar datos (sin retorno específico)
        Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model); // Para enviar datos (con retorno específico)
    }
}