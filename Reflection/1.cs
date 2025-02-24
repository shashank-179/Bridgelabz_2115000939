using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        Console.Write("Enter class name: ");
        string className = Console.ReadLine();

        Type type = Type.GetType(className);
        if (type == null)
        {
            Console.WriteLine("Class not found!");
            return;
        }

        Console.WriteLine($"Methods in {className}:");
        foreach (var method in type.GetMethods())
        {
            Console.WriteLine(method.Name);
        }

        Console.WriteLine($"\nFields in {className}:");
        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
        {
            Console.WriteLine(field.Name);
        }

        Console.WriteLine($"\nConstructors in {className}:");
        foreach (var ctor in type.GetConstructors())
        {
            Console.WriteLine(ctor);
        }
    }
}
