/*Problem 2: University with Faculties and Departments (Composition and Aggregation)
Description: Create a University with multiple Faculty members and Department objects. Model it so that the University and its Departments are in a composition relationship (deleting a university deletes all departments), and the Faculty members are in an aggregation relationship (faculty can exist outside of any specific department).
Tasks:
Define a University class with Department and Faculty classes.
Demonstrate how deleting a University also deletes its Departments.
Show that Faculty members can exist independently of a Department.
Goal: Understand the differences between composition and aggregation in modeling complex hierarchical relationships.
*/
using System;
using System.Collections.Generic;
class Faculty
{
    public string name;
    public string specialization;
    public Faculty(string name, string specialization)
    {
        this.name = name;
        this.specialization = specialization;
    }
    public void display() // Show faculty details
    {
        Console.WriteLine($"  Faculty: {name}, Specialization: {specialization}");
    }
}
class Department
{
    public string name;
    List<Faculty> faculties; // Aggregation: Faculties exist independently
    public Department(string name)
    {
        this.name = name;
        faculties = new List<Faculty>();
    }

    public void addFaculty(Faculty faculty) // Add faculty to department
    {
        faculties.Add(faculty);
    }

    public void display() // Show department details
    {
        Console.WriteLine($"Department: {name}");
        if (faculties.Count > 0)
        {
            Console.WriteLine("  Faculties:");
            foreach (Faculty faculty in faculties)
            {
                faculty.display();
            }
        }
        else
        {
            Console.WriteLine("  No faculties assigned.");
        }
    }
}

class University
{
    public string name;
    private List<Department> departments; // Composition: Departments belong to University
    public University(string name)
    {
        this.name = name;
        departments = new List<Department>();
    }

    public void addDepartment(Department department) // Add department to university
    {
        departments.Add(department);
    }

    public void DeleteUniversity() 
    { 
        Console.WriteLine($"\nDeleting University: {name}...");
        departments.Clear(); // Deleting all departments (Composition)
        Console.WriteLine("All departments have been deleted."); 
    }

    public void display() // Show university details
    {
        Console.WriteLine($"University: {name}");
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
            Console.WriteLine("No departments available.");
        }
    }

    public static void Main()
    {
        University university = new University("GLA University");

        Department cs = new Department("Computer Science");
        Department physics = new Department("Physics");

        Faculty f1 = new Faculty("Dr. Agarwal", "Artificial Intelligence");
        Faculty f2 = new Faculty("Dr. Ramlal", "Quantum Mechanics");
        Faculty f3 = new Faculty("Dr. Williams", "Data Science");

        cs.addFaculty(f1);
        cs.addFaculty(f3);
        physics.addFaculty(f2);

        university.addDepartment(cs);
        university.addDepartment(physics);

        // Display university details before deletion
        university.display();

        // Delete the university (demonstrating composition)
        university.DeleteUniversity();

        // Try displaying after deletion to confirm departments are removed
        university.display();
    }
}




