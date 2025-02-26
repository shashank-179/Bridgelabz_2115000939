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
            JObject jsonObject = JObject.Parse(jsonData);

            Console.WriteLine("\nAll Keys and Values:");
            foreach (var pair in jsonObject)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}
