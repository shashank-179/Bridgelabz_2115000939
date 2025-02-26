using System;
using System.IO;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter JSON file path: ");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            JArray users = JArray.Parse(jsonData);

            foreach (var user in users)
            {
                Console.WriteLine($"Name: {user["name"]}, Email: {user["email"]}");
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}
