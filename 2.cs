/* Write Data to a CSV File
Create a CSV file with employee details (ID, Name, Department, Salary).
Write at least 5 records to the file.
*/
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "employees.csv"; // File path

        string[] employees =
        {
            "ID,Name,Department,Salary",
            "201,Ramesh,HR,70000",
            "202,Suresh,IT,75000",
            "203,Mohan,Finance,65000",
            "204,Sohan,Marketing,60000",
            "205,Amit,Sales,55000"
        };

        File.WriteAllLines(filePath, employees);

        Console.WriteLine($"CSV file '{filePath}' created successfully!");
    }
}

