using Contrato.servicios.cliente;
using Dominio.Infraestructura;
using Dominio;
using Servicio;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Hosting;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

//Variables
var builder = WebApplication.CreateBuilder(args);
var Configuracion = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddDbContext<Contexto>(options => options.UseLazyLoadingProxies().UseSqlServer(Configuracion.GetConnectionString("DefaultConnection"), options => options.EnableRetryOnFailure()));
builder.Services.AddScoped(typeof(IServicioCliente), typeof(ServicioCliente));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();





app.Run();
