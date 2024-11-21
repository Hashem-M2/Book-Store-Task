using BookStore.Application.Implementations;
using BookStore.Application.Interfaces;
using BookStore.Application.Mapper;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));  // Register AutoMapper profile

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddDbContext<BookStoreContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
