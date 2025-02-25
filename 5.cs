/*Search for a Record in CSV
Read an employees.csv file and search for an employee by name.
Print their department and salary.
*/

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv"; // Path to the CSV file

        Console.Write("Enter employee name to search: ");
        string searchName = Console.ReadLine()?.Trim();

        if (File.Exists(filePath))
        {
            bool found = false;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool isHeader = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader) 
                    { 
                        isHeader = false; 
                        continue; // Skip header row
                    }

                    string[] fields = line.Split(',');
                    string name = fields[1].Trim(); // Employee Name

                    if (name.Equals(searchName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Employee Found: {name}");
                        Console.WriteLine($"Department: {fields[2]}");
                        Console.WriteLine($"Salary: {fields[3]}");
                        found = true;
                        break; // Stop searching after finding the first match
                    }
                }
            }

            if (!found)
                Console.WriteLine("Employee not found.");
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}

