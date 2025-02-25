/*Generate a CSV Report from Database
Fetch employee records from a database and write them into a CSV file.
Include headers: Employee ID, Name, Department, Salary.
*/
using System;
using System.Collections.Generic;
using System.IO;

class Employee
{
    public int EmployeeID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeID = 1, Name = "Alice", Department = "IT", Salary = 60000 },
            new Employee { EmployeeID = 2, Name = "Bob", Department = "HR", Salary = 50000 },
            new Employee { EmployeeID = 3, Name = "Charlie", Department = "Finance", Salary = 55000 }
        };

        string csvFilePath = "employees.csv";

        try
        {
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            {
                // Write CSV Headers
                writer.WriteLine("Employee ID,Name,Department,Salary");

                // Write Data Rows
                foreach (var emp in employees)
                {
                    writer.WriteLine($"{emp.EmployeeID},{emp.Name},{emp.Department},{emp.Salary}");
                }
            }
            Console.WriteLine($" CSV Report generated: {csvFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Error: {ex.Message}");
        }
    }
}

