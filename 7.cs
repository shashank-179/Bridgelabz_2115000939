/*Sort CSV Records by a Column
Read a CSV file and sort the records by Salary in descending order.
Print the top 5 highest-paid employees.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputFile = "employees.csv"; // CSV file path

        if (File.Exists(inputFile))
        {
            List<string[]> employeeData = new List<string[]>();
            string[] lines = File.ReadAllLines(inputFile);

            // Skip header and process records
            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');
                employeeData.Add(fields);
            }

            // Sort by Salary in descending order
            var sortedEmployees = employeeData.OrderByDescending(e => double.Parse(e[3])).Take(5);

            Console.WriteLine("Top 5 Highest Paid Employees:");
            Console.WriteLine("ID\tName\t\tDepartment\tSalary");
            Console.WriteLine("--------------------------------------------------");

            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"{employee[0]}\t{employee[1]}\t{employee[2]}\t{employee[3]}");
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}

