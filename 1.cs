/*Read a CSV File and Print Data
Read a CSV file containing student details (ID, Name, Age, Marks).
Print each record in a structured format.
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

                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) 
                    { 
                        isHeader = false; 
                        continue; // Skip header line
                    }

                    string[] fields = line.Split(',');

                    Console.WriteLine($"ID: {fields[0]}, Name: {fields[1]}, Age: {fields[2]}, Marks: {fields[3]}");
                }
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}



