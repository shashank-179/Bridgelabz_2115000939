using System;
using System.IO;
using Newtonsoft.Json;
using System.Data;

class Program
{
    static void Main()
    {
        Console.Write("Enter CSV file path: ");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            string[] headers = lines[0].Split(',');

            DataTable dt = new DataTable();
            foreach (var header in headers)
                dt.Columns.Add(header);

            for (int i = 1; i < lines.Length; i++)
                dt.Rows.Add(lines[i].Split(','));

            string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
            Console.WriteLine("\nConverted JSON:\n" + json);
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}
