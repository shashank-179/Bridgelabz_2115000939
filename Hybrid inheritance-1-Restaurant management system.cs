/*Restaurant Management System with Hybrid Inheritance
Description: Model a restaurant system where Person is the superclass and Chef and Waiter are subclasses. Both Chef and Waiter should implement a Worker interface that requires a PerformDuties() method.
Tasks:
Define a superclass Person with attributes like Name and Id.
Create an interface Worker with a method PerformDuties().
Define subclasses Chef and Waiter that inherit from Person and implement the Worker interface, each providing a unique implementation of PerformDuties().
Goal: Practice hybrid inheritance by combining inheritance and interfaces, giving multiple behaviors to the same objects.
using System;
*/


// Superclass: Person
class Person
{
    public string Name;
    public int Id;

    // Constructor to initialize Person attributes
    public Person(string Name, int Id)
    {
        this.Name = Name;
        this.Id = Id;
    }

    // Method to display personal details
    public void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name}\nID: {Id}");
    }
}

// Interface: Worker (Defines PerformDuties method)
interface Worker
{
    void PerformDuties();
}

// Subclass: Chef (Inherits from Person & Implements Worker)
class Chef : Person, Worker
{
    string Specialty;

    // Constructor to initialize Chef attributes
    public Chef(string Name, int Id, string Specialty)
        : base(Name, Id) // Calls base class constructor
    {
        this.Specialty = Specialty;
    }

    // Implementing PerformDuties() method
    public void PerformDuties()
    {
        Console.WriteLine("Role: Chef");
        base.DisplayDetails();
        Console.WriteLine($"Specialty: {Specialty}");
        Console.WriteLine("Duties: Cooking and preparing meals.");
    }
}

// Subclass: Waiter (Inherits from Person & Implements Worker)
class Waiter : Person, Worker
{
    int TableCount;

    // Constructor to initialize Waiter attributes
    public Waiter(string Name, int Id, int TableCount)
        : base(Name, Id) // Calls base class constructor
    {
        this.TableCount = TableCount;
    }

    // Implementing PerformDuties() method
    public void PerformDuties()
    {
        Console.WriteLine("Role: Waiter");
        base.DisplayDetails();
        Console.WriteLine($"Tables Assigned: {TableCount}");
        Console.WriteLine("Duties: Serving food and taking orders.");
    }
}

// Main class
class Program
{
    public static void Main()
    {
        // Creating Chef object
        Chef chef = new Chef("Ram", 101, "Chinese Cuisine");

        // Creating Waiter object
        Waiter waiter = new Waiter("Vinay", 202, 5);

        // Displaying duties
        chef.PerformDuties();
        Console.WriteLine();
        waiter.PerformDuties();
    }
}

