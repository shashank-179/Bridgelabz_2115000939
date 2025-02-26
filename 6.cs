using System;
using System.Collections.Generic;
using Newtonsoft.Json;

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("Enter number of employees: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write($"Enter Name of Employee {i+1}: ");
            string name = Console.ReadLine();

            Console.Write($"Enter Age of Employee {i+1}: ");
            int age = int.Parse(Console.ReadLine());

            employees.Add(new Employee { Name = name, Age = age });
        }

        string jsonArray = JsonConvert.SerializeObject(employees, Formatting.Indented);
        Console.WriteLine("\nJSON Array:\n" + jsonArray);
    }
}
