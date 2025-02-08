/*School System with Different Roles
Description: Create a hierarchy for a school system where Person is the superclass, and Teacher, Student, and Staff are subclasses.
Tasks:
Define a superclass Person with common attributes like Name and Age.
Define subclasses Teacher, Student, and Staff with specific attributes (e.g., Subject for Teacher and Grade for Student).
Each subclass should have a method like DisplayRole() that describes the role.
Goal: Demonstrate hierarchical inheritance by modeling different roles in a school, each with shared and unique characteristics.
*/

using System;

// Base class: Person
class Person
{
    string Name;
    int Age;

    // Constructor to initialize common attributes
    public Person(string Name, int Age)
    {
        this.Name = Name;
        this.Age = Age;
    }

    // Method to display person details
    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}\nAge: {Age}");
    }

    // Virtual method to be overridden in subclasses
    public void DisplayRole()
    {
        Console.WriteLine("Role: General Person");
    }
}

// Subclass: Teacher (Inherits from Person)
class Teacher : Person
{
    string Subject;

    // Constructor to initialize teacher attributes
    public Teacher(string Name, int Age, string Subject)
        : base(Name, Age) // Calls base class constructor
    {
        this.Subject = Subject;
    }

    // Overriding DisplayRole() method
    public void DisplayRole()
    {
        Console.WriteLine("Role: Teacher");
        base.DisplayDetails(); // Calls base class method
        Console.WriteLine($"Subject: {Subject}");
    }
}

// Subclass: Student (Inherits from Person)
class Student : Person
{
    string Grade;

    // Constructor to initialize student attributes
    public Student(string Name, int Age, string Grade)
        : base(Name, Age) // Calls base class constructor
    {
        this.Grade = Grade;
    }

    // Overriding DisplayRole() method
    public  void DisplayRole()
    {
        Console.WriteLine("Role: Student");
        base.DisplayDetails(); // Calls base class method
        Console.WriteLine($"Grade: {Grade}");
    }
}

// Subclass: Staff (Inherits from Person)
class Staff : Person
{
    string Department;

    // Constructor to initialize staff attributes
    public Staff(string Name, int Age, string Department)
        : base(Name, Age) // Calls base class constructor
    {
        this.Department = Department;
    }

    // Overriding DisplayRole() method
    public  void DisplayRole()
    {
        Console.WriteLine("Role: Staff");
        base.DisplayDetails(); // Calls base class method
        Console.WriteLine($"Department: {Department}");
    }
}

// Main class
class Program
{
    public static void Main()
    {
        // Creating Teacher object
        Teacher teacher = new Teacher("Suresh", 40, "Mathematics");

        // Creating Student object
        Student student = new Student("Shashank", 18, "12th Grade");

        // Creating Staff object
        Staff staff = new Staff("Dinesh", 35, "Peon");

        // Displaying roles and details
        teacher.DisplayRole();
        Console.WriteLine();
        student.DisplayRole();
        Console.WriteLine();
        staff.DisplayRole();
    }
}

