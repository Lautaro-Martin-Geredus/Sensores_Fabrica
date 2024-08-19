using Api_Sensors.Models;
using Api_Sensors.Repository;
using Api_Sensors.Repository.Impl;
using Api_Sensors.Services;
using Api_Sensors.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

builder.Services.AddDbContext<ApiSensoresContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConexionDB"));
});

builder.Services.AddScoped<ISensorRepository, SensorRepositoryImpl>();
builder.Services.AddScoped<ISensorService, SensorServiceImpl>();

builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();

builder.Services.AddScoped<IReadingRepository, ReadingRepositoryImpl>();
builder.Services.AddScoped<IReadingService, ReadingServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
