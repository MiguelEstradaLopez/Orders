using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Orders.Frontend;
using Orders.Frontend.Repositories;
using CurrieTechnologies.Razor.SweetAlert2; // Necesario para SweetAlert2
using System.Net.Http; // Necesario para HttpClient

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configura la base de la URL para las llamadas HTTP al Backend
// Asegúrate de que esta URL coincida con la URL de tu Backend (ej. https://localhost:7201/)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7201/") });

// Inyecta el repositorio para manejar las llamadas a la API
builder.Services.AddScoped<IRepository, Repository>();

// Agrega el servicio de SweetAlert2 para mostrar alertas bonitas
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
