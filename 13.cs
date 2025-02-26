using System;
using System.IO;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter first JSON file path: ");
        string file1 = Console.ReadLine();

        Console.Write("Enter second JSON file path: ");
        string file2 = Console.ReadLine();

        if (File.Exists(file1) && File.Exists(file2))
        {
            JObject json1 = JObject.Parse(File.ReadAllText(file1));
            JObject json2 = JObject.Parse(File.ReadAllText(file2));

            json1.Merge(json2);

            Console.WriteLine("\nMerged JSON:\n" + json1.ToString());
        }
        else
        {
            Console.WriteLine("One or both files not found!");
        }
    }
}
