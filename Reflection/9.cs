using System;
using System.Reflection;

class Person
{
    public string Name = "Alice";
    public int Age = 25;
}

class Program
{
    static string ToJson(object obj)
    {
        Type type = obj.GetType();
        string json = "{ ";
        foreach (var field in type.GetFields())
        {
            json += $"\"{field.Name}\": \"{field.GetValue(obj)}\", ";
        }
        return json.TrimEnd(',', ' ') + " }";
    }

    static void Main()
    {
        Person person = new Person();
        Console.WriteLine(ToJson(person));
    }
}
