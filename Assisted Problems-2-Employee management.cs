/*Employee Management System
Description:
Create an Employee hierarchy for different employee types such as Manager, Developer, and Intern.
Tasks:
Define a base class Employee:
Add three attributes: Name (string), Id (integer), and Salary (double).
Add a method DisplayDetails() to display the details of an employee.
Define subclasses Manager, Developer, and Intern:
Manager: Add an additional attribute TeamSize (integer).
Developer: Add an additional attribute ProgrammingLanguage (string).
Intern: Add an additional attribute InternshipDuration (string).
Goal:
Practice inheritance by creating subclasses with specific attributes and overriding superclass methods (e.g., DisplayDetails()) to display details specific to each type of employee
*/

using System;

// Base class Employee
class Employee
{
    public string Name;
    public int Id;
    public double Salary;

    // Constructor
    public Employee(string name, int id, double salary)
    {
        Name = name;
        Id = id;
        Salary = salary;
    }

    // Virtual method for displaying details
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Employee name: {Name}\nEmployee id: {Id}\nEmployee salary: {Salary}");
    }
}

// Manager class inheriting from Employee
class Manager : Employee
{
    int TeamSize;

    // Constructor with additional TeamSize attribute
    public Manager(string name, int id, double salary, int teamSize)
        : base(name, id, salary)
    {
        TeamSize = teamSize;
    }

    // Overriding DisplayDetails method
    public override void DisplayDetails()
    {
        Console.WriteLine($"Employee name: {Name}\nEmployee id: {Id}\nEmployee salary: {Salary}\nTeam size: {TeamSize}");
    }
}

// Developer class inheriting from Employee
class Developer : Employee
{
    string ProgrammingLanguage;

    // Constructor with additional ProgrammingLanguage attribute
    public Developer(string name, int id, double salary, string programmingLanguage)
        : base(name, id, salary)
    {
        ProgrammingLanguage = programmingLanguage;
    }

    // Overriding DisplayDetails method
    public override void DisplayDetails()
    {
        Console.WriteLine($"Employee name: {Name}\nEmployee id: {Id}\nEmployee salary: {Salary}\nProgramming Language: {ProgrammingLanguage}");
    }
}

// Intern class inheriting from Employee
class Intern : Employee
{
    string InternshipDuration;

    // Constructor with additional InternshipDuration attribute
    public Intern(string name, int id, double salary, string internshipDuration)
        : base(name, id, salary)
    {
        InternshipDuration = internshipDuration;
    }

    // Overriding DisplayDetails method
    public override void DisplayDetails()
    {
        Console.WriteLine($"Employee name: {Name}\nEmployee id: {Id}\nEmployee salary: {Salary}\nInternship Duration: {InternshipDuration}");
    }
}

// Main program
class Program
{
    public static void Main()
    {
        // Creating objects of different employee types
        Employee employee = new Employee("Shashank", 12, 4.25);
        Employee manager = new Manager("Shashank", 12, 4.25, 5);
        Employee developer = new Developer("Shashank", 12, 4.25, "C#");
        Employee intern = new Intern("Shashank", 12, 4.25, "3 months");

        // Displaying employee details
        employee.DisplayDetails();
        manager.DisplayDetails();
        developer.DisplayDetails();
        intern.DisplayDetails();
    }
}

