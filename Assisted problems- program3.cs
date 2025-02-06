/*Problem 3: Company and Departments (Composition)
Description: A Company has several Department objects, and each department contains Employee objects. Model this using composition, where deleting a Company should also delete all departments and employees.
Tasks:
Define a Company class that contains multiple Department objects.
Define an Employee class within each Department.
Show the composition relationship by ensuring that when a Company object is deleted, all associated Department and Employee objects are also removed.
Goal: Understand composition by implementing a relationship where Department and Employee objects cannot exist without a Company.
*/
using System;
using System.Collections.Generic;

class Employee
{
    public int empId { get; set; }
    public string name;
    public string position;

    public Employee(int empId, string name, string position)
    {
        this.empId = empId;
        this.name = name;
        this.position = position;
    }

    public void display() // Display employee details
    {
        Console.WriteLine($"  Employee ID: {empId}, Name: {name}, Position: {position}");
    }
}

class Department
{
    public string name { get; set; }
    private List<Employee> employees;



    public Department(string name)
    {
        this.name = name;
        employees = new List<Employee>();
    }

    public void addEmployee(Employee employee) // Add employee to department
    {
        employees.Add(employee);
    }

    public void display() // Display department details
    {
        Console.WriteLine($"Department: {name}");
        if (employees.Count > 0)
        {
            Console.WriteLine("  Employees:");
            foreach (Employee emp in employees)
            {
                emp.display();
            }
        }
        else
        {
            Console.WriteLine("  No employees in this department.");
        }
    }
}

class Company
{
    public string CompanyName { get; private set; }
    private List<Department> departments;

    public Company(string companyName)
    {
        CompanyName = companyName;
        departments = new List<Department>();
    }

    public void AddDepartment(Department department) // Add department to company
    {
        departments.Add(department);
    }

    public void display() // Display company details
    {
        Console.WriteLine($"Company: {CompanyName}");
        if (departments.Count > 0)
        {
            Console.WriteLine("Departments:");
            foreach (Department department in departments)
            {
                department.display();
            }
        }
        else
        {
            Console.WriteLine("No departments in this company.");
        }
    }

    public static void Main() // Main method
    {
        Employee emp1 = new Employee(1, "Ram", "Technical Manager");
        Employee emp2 = new Employee(2, "Shyam", "Manager");
        Employee emp3 = new Employee(3, "Ghanshyam", "Team Lead");
        Employee emp4 = new Employee(4, "Naina", "Techie");
        Employee emp5 = new Employee(5, "Sunaina", "Finance Lead");

        Department d1 = new Department("IT Department");
        Department d2 = new Department("HR Department");
        Department d3 = new Department("Finance Department");

        Company c1 = new Company("Capg");

        d1.addEmployee(emp1);
        d1.addEmployee(emp3);
        d1.addEmployee(emp4);
        d2.addEmployee(emp2);
        d3.addEmployee(emp5);

        c1.AddDepartment(d1);
        c1.AddDepartment(d2);
        c1.AddDepartment(d3);

        c1.display();
    }
}




