using CourseWork.Data;
using CourseWork.Models;
using CourseWork.Models.Visitors;
using CourseWork.Services;
using Microsoft.EntityFrameworkCore;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EFContext>((DbContextOptionsBuilder b) => {
    b.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IIngredientsDictionary, IngredientsDictionary>();
builder.Services.AddScoped<IManagerProduct, ManagerProduct>();
builder.Services.AddScoped<IManagerProduct, ManagerProduct>();
builder.Services.AddScoped<IVisitor, RestaurantVisitor>();

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