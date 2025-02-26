using System;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        Console.Write("Enter first JSON: ");
        string json1 = Console.ReadLine();

        Console.Write("Enter second JSON: ");
        string json2 = Console.ReadLine();

        JObject obj1 = JObject.Parse(json1);
        JObject obj2 = JObject.Parse(json2);

        obj1.Merge(obj2);

        Console.WriteLine("\nMerged JSON:\n" + obj1.ToString());
    }
}
