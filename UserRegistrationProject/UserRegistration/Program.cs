using BusinessLayer.Service;
using RepositoryLayer.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Adding registration service from bussiness layer in UserRegistration Application
builder.Services.AddScoped<UserRegistrationBL>();
//Adding registration service from repository layer in UserRegistration Application
builder.Services.AddScoped<UserRegistrationRL>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
