/*Implement Context Layer
Create a DbContext class using Entity Framework Core.
Define entity models and DbSet properties.
Configure a database connection in appsettings.json.
Register DbContext in the application services.
*/

namespace RepositoryLayer.Context
{
public class UserRegistrationAppContext : DbContext
{
public
UserRegistrationAppContext(DbContextOptions<UserRegistrat
ionAppContext> options) : base(options) { }
public virtual DbSet<Entity.UserEntity> Users {
get; set; }
}
}
namespace RepositoryLayer.Entity
{
public class UserEntity
{
[Key]
public int UserId { get; set; }
[Required]public string FirstName { get; set; }
[Required]
public string LastName { get; set; }
[Required]
public string Email { get; set; }
[Required]
public string Password { get; set; }
}
}


