/*4️⃣ Create a MaxLength Attribute for Field Validation
Problem Statement: Define a field-level attribute MaxLength(int value) that restricts the maximum length of a string field.
Requirements:
Apply it to a User class field (Username).
Validate length in the constructor.
Throw ArgumentException if the limit is exceeded.
*/
using System;
using System.Reflection;

// Step 1: Define a MaxLength attribute
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
class MaxLengthAttribute : Attribute
{
    public int Length { get; }

    public MaxLengthAttribute(int length)
    {
        Length = length;
    }
}

// Step 2: Apply it to a User class
class User
{
    [MaxLength(10)]
    public string Username { get; }

    public User(string username)
    {
        ValidateMaxLength(this, nameof(Username), username);
        Username = username;
    }

    private void ValidateMaxLength(object obj, string fieldName, string value)
    {
        FieldInfo field = obj.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
        
        if (field != null && field.GetCustomAttribute(typeof(MaxLengthAttribute)) is MaxLengthAttribute attr)
        {
            if (value.Length > attr.Length)
            {
                throw new ArgumentException($"Error: {fieldName} cannot exceed {attr.Length} characters.");
            }
        }
    }
}

// Step 3: Test the attribute
class Program
{
    static void Main()
    {
        try
        {
            User validUser = new User("Amit"); // Valid username
            Console.WriteLine($"Username set: {validUser.Username}");

            User invalidUser = new User("VeryLongUsername"); // Exceeds max length, throws error
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

