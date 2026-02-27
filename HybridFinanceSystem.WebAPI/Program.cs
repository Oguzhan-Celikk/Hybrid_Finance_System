using HybridFinanceSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using HybridFinanceSystem.Application.Interfaces;
using HybridFinanceSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// WebAPI -> Program.cs
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Mevcut satırın
    app.MapScalarApiReference(); // Bunu ekle!
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();