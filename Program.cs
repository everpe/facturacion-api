using AutoMapper;
using Facturacion.Api.Interfaces;
using Facturacion.Api.Persistence;
using Facturacion.Api.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using static Facturacion.Api.Mediators.CreateInvoiceMediator;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<InsertInvoiceValidation>();
builder.Services.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<InsertInvoiceValidation>());

//builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddValidatorsFromAssemblyContaining<InsertInvoiceValidation>();
//builder.Services.AddFluent(config => config.RegisterValidatorsFromAssemblyContaining<FacturaValidator>());
builder.Services.AddScoped<FacturacionDataContext>();
builder.Services.AddScoped<IFactura, FacturaService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V1",
        Title = "API Facturación",
        Description = "Api para el manejo de modelo facturas.",

    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



builder.Services.AddDbContext<FacturacionDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(typeof(Program));
// Configurar MediatR
builder.Services.AddMediatR(typeof(Program).Assembly);


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
