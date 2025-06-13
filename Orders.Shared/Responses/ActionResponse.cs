namespace Orders.Shared.Responses
{
    public class ActionResponse<T>
    {
        public bool WasSuccess { get; set; } // Indica si la acción fue exitosa
        public string? Message { get; set; } // Mensaje de la acción
        public T? Result { get; set; } // Resultado de la acción
    }
}