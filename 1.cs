using System;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter Student Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter Subjects (comma-separated): ");
        string[] subjects = Console.ReadLine().Split(',');

        var student = new
        {
            name = name,
            age = age,
            subjects = subjects
        };

        string jsonString = JsonConvert.SerializeObject(student, Formatting.Indented);
        Console.WriteLine("\nGenerated JSON:\n" + jsonString);
    }
}
