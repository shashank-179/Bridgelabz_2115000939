/*Educational Course Hierarchy
Description: Model a course system where Course is the base class, OnlineCourse is a subclass, and PaidOnlineCourse extends OnlineCourse.
Tasks:
Define a superclass Course with attributes like CourseName and Duration.
Define OnlineCourse to add attributes such as Platform and IsRecorded.
Define PaidOnlineCourse to add Fee and Discount.
Goal: Demonstrate how each level of inheritance builds on the previous, adding complexity to the system.
*/

using System;
// Base class: Course
class Course
{
    string CourseName;
    string Duration;
    // Constructor to initialize course attributes
    public Course(string CourseName, string Duration)
    {
        this.CourseName = CourseName;
        this.Duration = Duration;
    }
    // Method to display course details
    public void Display()
    {
        Console.WriteLine($"Course\nCourse Name: {CourseName}\nDuration: {Duration}");
    }
}

// Subclass: OnlineCourse (Inherits from Course)
class OnlineCourse : Course
{
    string Platform;
    bool IsRecorded;

    // Constructor to initialize online course attributes
    public OnlineCourse(string CourseName, string Duration, string Platform, bool IsRecorded)
        : base(CourseName, Duration) // Calls base class constructor
    {
        this.Platform = Platform;
        this.IsRecorded = IsRecorded;
    }

    // Method to display online course details
    public void Display()
    {
        base.Display(); // Calls base class Display() method
        Console.WriteLine($"Online Course\nPlatform Name: {Platform}\nRecording Available: {IsRecorded}");
    }
}

// Subclass: PaidOnlineCourse (Inherits from OnlineCourse)
class PaidOnlineCourse : OnlineCourse
{
    int fee;
    double discount;

    // Constructor to initialize paid online course attributes
    public PaidOnlineCourse(string CourseName, string Duration, string Platform, bool IsRecorded, int fee, double discount)
        : base(CourseName, Duration, Platform, IsRecorded) // Calls base class constructor
    {
        this.fee = fee;
        this.discount = discount;
    }

    // Method to display paid online course details
    public void Display()
    {
        base.Display(); // Calls base class Display() method
        Console.WriteLine($"Paid Online Course\nFee: {fee}\nDiscount: {discount}%");
    }
}

// Main class
class Program
{
    public static void Main()
    {
        // Creating a Course object
        Course course = new Course("Capgemini Training", "3 months");

        // Creating an OnlineCourse object
        OnlineCourse online = new OnlineCourse("Capgemini Training", "3 months", "Bridgelabz", false);

        // Creating a PaidOnlineCourse object
        PaidOnlineCourse paid = new PaidOnlineCourse("Capgemini Training", "3 months", "Bridgelabz", false, 20000, 10);

        // Displaying course details
        course.Display();
        Console.WriteLine();

        // Displaying online course details
        online.Display();
        Console.WriteLine();

        // Displaying paid online course details
        paid.Display();
    }
}

