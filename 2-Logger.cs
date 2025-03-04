/*Implement Logger
Configure a logging mechanism (e.g.,NLog) for tracking API requests and errors.
Store logs in both console and file storage.
Implement logging inside controllers for request tracing.
*/

var logger =
NLog.LogManager.Setup().LoadConfigurationFromAppSettings(
).GetCurrentClassLogger();
try
{
logger.Info("Starting application....");
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<RegisterUserBL>();
builder.Services.AddScoped<RegisterUserRL>();// database Service
var connectionString =
builder.Configuration.GetConnectionString("SqlConnection"
);
builder.Services.AddDbContext<UserRegistrationAppContext>
(options => options.UseSqlServer(connectionString));
//add Swagger to container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
//use swagger
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
}
catch (Exception ex)
{
logger.Error(ex, "Application startup failed");
throw;
}finally
{
NLog.LogManager.Shutdown();
}

