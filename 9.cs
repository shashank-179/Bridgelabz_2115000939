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
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Rahul", Age = 28 },
            new Employee { Name = "Priya", Age = 24 },
            new Employee { Name = "Amit", Age = 30 }
        };

        string jsonArray = JsonConvert.SerializeObject(employees, Formatting.Indented);
        Console.WriteLine("\nJSON Array:\n" + jsonArray);
    }
}
