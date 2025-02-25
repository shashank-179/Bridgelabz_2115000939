/* Filter Records from CSV
Read a CSV file and filter students who have scored more than 80 marks.
Print only the qualifying records.
*/

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "students.csv"; // Path to the CSV file

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;

                Console.WriteLine("Students with Marks > 80:");

                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) 
                    { 
                        isHeader = false; 
                        continue; // Skip header row
                    }

                    string[] fields = line.Split(',');
                    int marks = int.Parse(fields[3]);

                    if (marks > 80)
                    {
                        Console.WriteLine($"ID: {fields[0]}, Name: {fields[1]}, Age: {fields[2]}, Marks: {fields[3]}");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}

