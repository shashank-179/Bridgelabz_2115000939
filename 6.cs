/*Modify a CSV File (Update a Value)
Read a CSV file and increase the salary of employees from the "IT" department by 10%.
Save the updated records back to a new CSV file
*/

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string inputFile = "employees.csv"; // Original CSV file
        string outputFile = "updated_employees.csv"; // Updated CSV file
        List<string> updatedLines = new List<string>();

        if (File.Exists(inputFile))
        {
            using (StreamReader reader = new StreamReader(inputFile))
            {
                string line;
                bool isHeader = true;

                while ((line = reader.ReadLine()) != null)
                {
                    if (isHeader)
                    {
                        updatedLines.Add(line); // Keep the header
                        isHeader = false;
                        continue;
                    }

                    string[] fields = line.Split(',');
                    string department = fields[2].Trim(); // Department
                    double salary = double.Parse(fields[3]); // Salary

                    if (department.Equals("IT", StringComparison.OrdinalIgnoreCase))
                    {
                        salary *= 1.10; // Increase by 10%
                    }

                    updatedLines.Add($"{fields[0]},{fields[1]},{fields[2]},{salary:F2}"); // Format salary
                }
            }

            // Write updated data to a new CSV file
            File.WriteAllLines(outputFile, updatedLines);
            Console.WriteLine("Salaries updated successfully. Check 'updated_employees.csv'.");
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}



