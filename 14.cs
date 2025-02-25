/*Convert JSON to CSV and Vice Versa
Read a JSON file containing a list of students.
Convert it into CSV format and save it.
Implement another method to read CSV and convert it back to JSON.
*/

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Student
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Marks { get; set; }
}

class Program
{
    static void Main()
    {
        string jsonFile = "students.json";
        string csvFile = "students.csv";
        string jsonOutputFile = "students_output.json";

        // Convert JSON to CSV
        ConvertJsonToCsv(jsonFile, csvFile);
        Console.WriteLine("JSON to CSV conversion completed.");

        // Convert CSV to JSON
        ConvertCsvToJson(csvFile, jsonOutputFile);
        Console.WriteLine("CSV to JSON conversion completed.");
    }

    // Method to convert JSON to CSV
    static void ConvertJsonToCsv(string jsonFile, string csvFile)
    {
        string jsonData = File.ReadAllText(jsonFile);
        List<Student> students = JsonConvert.DeserializeObject<List<Student>>(jsonData);

        using (StreamWriter writer = new StreamWriter(csvFile))
        {
            writer.WriteLine("ID,Name,Age,Marks"); // Write CSV Header

            foreach (var student in students)
            {
                writer.WriteLine($"{student.ID},{student.Name},{student.Age},{student.Marks}");
            }
        }
    }

    // Method to convert CSV to JSON
    static void ConvertCsvToJson(string csvFile, string jsonOutputFile)
    {
        List<Student> students = new List<Student>();
        string[] lines = File.ReadAllLines(csvFile);

        for (int i = 1; i < lines.Length; i++) // Skip header row
        {
            string[] data = lines[i].Split(',');

            students.Add(new Student
            {
                ID = int.Parse(data[0]),
                Name = data[1],
                Age = int.Parse(data[2]),
                Marks = int.Parse(data[3])
            });
        }

        string jsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(jsonOutputFile, jsonData);
    }
}

