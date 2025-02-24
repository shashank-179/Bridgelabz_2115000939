using System;
using System.Collections.Generic;
using System.Reflection;

class User
{
    public string Name;
    public int Age;
}

class Program
{
    static T ToObject<T>(Type clazz, Dictionary<string, object> properties) where T : new()
    {
        T obj = new T();
        foreach (var prop in properties)
        {
            FieldInfo field = clazz.GetField(prop.Key);
            field?.SetValue(obj, prop.Value);
        }
        return obj;
    }

    static void Main()
    {
        Dictionary<string, object> data = new Dictionary<string, object> { { "Name", "Alice" }, { "Age", 25 } };
        User user = ToObject<User>(typeof(User), data);
        Console.WriteLine($"User: {user.Name}, Age: {user.Age}");
    }
}
