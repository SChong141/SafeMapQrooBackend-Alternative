using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SafeMapQROOBackend.Data;
using SafeMapQROOBackend.Interfaces;
using SafeMapQROOBackend.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// Configuiracion de Contexto de Base de Datos
builder.Services.AddDbContext<ApplicationDBContext>(Options => Options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IShelterRepository, ShelterRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();