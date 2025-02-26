using System;
using System.IO;
using System.Linq;
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

            var filteredUsers = users.Where(user => (int)user["age"] > 25);

            Console.WriteLine("\nUsers older than 25:");
            foreach (var user in filteredUsers)
            {
                Console.WriteLine(user.ToString());
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}

