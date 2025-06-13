using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Orders.Frontend.Shared
{
    public partial class GenericList<Titem>
    {
        [EditorRequired, Parameter] public List<Titem> MyList { get; set; } = null!; // La lista de ítems a mostrar
        [Parameter] public RenderFragment? Loading { get; set; } // Fragmento para mostrar durante la carga
        [Parameter] public RenderFragment? NoRecords { get; set; } // Fragmento para mostrar cuando no hay registros
        [EditorRequired, Parameter] public RenderFragment Body { get; set; } = null!; // Contenido principal a renderizar
    }
}
