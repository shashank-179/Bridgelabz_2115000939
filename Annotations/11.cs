/*6️⃣ Implement a Custom Serialization Attribute JsonField
Problem Statement: Define an attribute JsonField to mark fields for JSON serialization.
Requirements:
[JsonField(Name = "user_name")] should map field names to custom JSON keys.
Apply it on a User class.
Write a method to convert an object to a JSON string by reading the attributes.
*/
using System;
using System.Reflection;
using System.Text;
using System.Collections.Generic;

// Step 1: Define a JsonField attribute
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
class JsonFieldAttribute : Attribute
{
    public string Name { get; }

    public JsonFieldAttribute(string name)
    {
        Name = name;
    }
}

// Step 2: Apply the attribute to the User class
class User
{
    [JsonField(Name = "user_name")]
    public string Username { get; set; }

    [JsonField(Name = "user_age")]
    public int Age { get; set; }

    [JsonField(Name = "is_active")]
    public bool IsActive { get; set; }

    public string IgnoreThisField { get; set; } // No attribute → Should be ignored in JSON
}

// Step 3: Serialize object to JSON by reading attributes
class JsonSerializer
{
    public static string Serialize(object obj)
    {
        Type type = obj.GetType();
        var jsonKeyValuePairs = new List<string>();

        foreach (PropertyInfo prop in type.GetProperties())
        {
            if (prop.GetCustomAttribute(typeof(JsonFieldAttribute)) is JsonFieldAttribute attr)
            {
                object value = prop.GetValue(obj);
                string jsonValue = value is string ? $"\"{value}\"" : value.ToString();
                jsonKeyValuePairs.Add($"\"{attr.Name}\": {jsonValue}");
            }
        }

        return "{ " + string.Join(", ", jsonKeyValuePairs) + " }";
    }
}

// Step 4: Test serialization
class Program
{
    static void Main()
    {
        User user = new User { Username = "Shashank", Age = 22, IsActive = true, IgnoreThisField = "This should be ignored" };

        string json = JsonSerializer.Serialize(user);
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);
    }
}

