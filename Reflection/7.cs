using System;
using System.Reflection;

class Configuration
{
    private static string API_KEY = "OriginalKey";
}

class Program
{
    static void Main()
    {
        Type type = typeof(Configuration);
        FieldInfo field = type.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

        field.SetValue(null, "NewSecretKey");
        Console.WriteLine("Updated API_KEY: " + field.GetValue(null));
    }
}
