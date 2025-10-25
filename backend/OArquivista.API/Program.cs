using Microsoft.EntityFrameworkCore;
using OArquivista.API.Models;
using OArquivista.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("OArquivistaDB"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAngularApp");

app.MapGet("/api/livros", async (AppDbContext db) =>
{
    var livros = await db.Livros.ToListAsync();
    return Results.Ok(livros);
});

app.MapPost("/api/livros", async (AppDbContext db, Livro novoLivro) =>
{
    db.Livros.Add(novoLivro);
    await db.SaveChangesAsync();
    return Results.Created($"/api/livros/{novoLivro.Id}", novoLivro);
});

app.Run();