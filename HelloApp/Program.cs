using BusinessLayer.Service;
using RepositoryLayer.Service;
using BusinessLayer.Interface;
using RepositoryLayer.Interface;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//object making

builder.Services.AddScoped<IRegisterHelloRL, RegisterHelloRL>();
builder.Services.AddScoped<IRegisterHelloBL,RegisterHelloBL>();
//adds regusterhello as a service
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddDbContext<HelloAppContext>(options=>options.UseSqlServer(connectionString));
//Add swagger to container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
//Middleware

app.UseHttpsRedirection();
//http request into https request 

app.UseAuthorization();
//used to authorize apis

app.MapControllers();
//used to map controllers

app.Run();
//ending point of all middleware
