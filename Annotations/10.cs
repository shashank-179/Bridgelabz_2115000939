/*Advanced Level
5️⃣ Implement Role-Based Access Control with RoleAllowed
Problem Statement: Define a class-level attribute RoleAllowed to restrict method access based on roles.
Requirements:
[RoleAllowed("ADMIN")] should only allow ADMIN users to execute the method.
Simulate user roles and validate access before invoking the method.
If a non-admin tries to access it, print Access Denied!
*/
using System;
using System.Reflection;

// Step 1: Define a RoleAllowed attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
class RoleAllowedAttribute : Attribute
{
    public string Role { get; }

    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

// Step 2: Apply the attribute to a restricted method
class UserManagement
{
    [RoleAllowed("ADMIN")]
    public void DeleteUser()
    {
        Console.WriteLine("User deleted successfully.");
    }
}

// Step 3: Simulate user authentication and check access before invoking the method
class Program
{
    static void ExecuteIfAuthorized(object obj, string methodName, string userRole)
    {
        MethodInfo method = obj.GetType().GetMethod(methodName);
        
        if (method.GetCustomAttribute(typeof(RoleAllowedAttribute)) is RoleAllowedAttribute attr)
        {
            if (attr.Role == userRole)
            {
                method.Invoke(obj, null);
            }
            else
            {
                Console.WriteLine("Access Denied!");
            }
        }
        else
        {
            method.Invoke(obj, null);
        }
    }

    static void Main()
    {
        UserManagement um = new UserManagement();

        string currentUserRole = "USER"; // Change to "ADMIN" to allow access

        Console.WriteLine($"Current User Role: {currentUserRole}");
        ExecuteIfAuthorized(um, "DeleteUser", currentUserRole);
    }
}

