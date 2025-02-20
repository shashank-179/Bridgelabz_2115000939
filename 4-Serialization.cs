/*Serialization - Save and Retrieve an Object 
📌 Problem Statement: Design a C# program that allows a user to store a list of employees in a file using Object Serialization and later retrieve the data from the file. 
Requirements: Create an Employee class with fields: id, name, department, salary. Serialize the list of employees into a file (BinaryFormatter / JSON Serialization).
Deserialize and display the employees from the file. Handle exceptions properly.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


public class Employee
{
   public int Id { get; set; }
   public string Name { get; set; }
   public string Department { get; set; }
   public double Salary { get; set; }
}

class Serialization
{
   public static void SerializeEmployees(List<Employee> employees, string filePath)
   {
       try
       {
           string jsonString = JsonSerializer.Serialize(employees);
           File.WriteAllText(filePath, jsonString);
           Console.WriteLine("Employees serialized successfully.");
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error: " + ex.Message);
       }
   }

   public static List<Employee> DeserializeEmployees(string filePath)
   {
       try
       {
           if (!File.Exists(filePath))
           {
               Console.WriteLine("File does not exist.");
               return new List<Employee>();
           }

           string jsonString = File.ReadAllText(filePath);
           return JsonSerializer.Deserialize<List<Employee>>(jsonString);
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error: " + ex.Message);
           return new List<Employee>();
       }
   }

   public static void Main(string[] args)
   {
       string filePath = "employees.json";

       List<Employee> employees = new List<Employee>
       {
           new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
           new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 }
       };

       SerializeEmployees(employees, filePath);

       List<Employee> deserializedEmployees = DeserializeEmployees(filePath);

       foreach (var emp in deserializedEmployees)
       {
           Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
       }
   }
}



