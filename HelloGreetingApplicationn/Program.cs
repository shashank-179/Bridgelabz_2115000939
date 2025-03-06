using Business_Layer.Interface;
using Business_Layer.Service;
using Repository_Layer.Service;
using Repository_Layer.Interface;
using Model_Layer.Model;
using Microsoft.EntityFrameworkCore;
using Repository_Layer.Context;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<GreetingBL>();
builder.Services.AddScoped<GreetingRL>();
builder.Services.AddScoped<IGreetingBL,GreetingBL>();
builder.Services.AddScoped<IGreetingRL,GreetingRL>();
builder.Services.AddScoped<UserModel>();
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect(builder.Configuration["Redis:ConnectionString"] ?? "localhost:6379"));


builder.Services.AddSingleton<RedisCacheService>();


var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddDbContext<GreetingDbContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
