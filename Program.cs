using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pasarela.Service;

var builder = WebApplication.CreateBuilder(args);

// Añadir servicios al contenedor
builder.Services.AddControllers();

// Añadir tu servicio personalizado (si no se inyecta desde el contenedor)
builder.Services.AddSingleton<PasarelaService>();

var app = builder.Build();

// Configurar el pipeline HTTP
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Asegúrate de que se mapeen los controladores
});

app.Run();
