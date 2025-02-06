/*Problem 5: University Management System
Description: Model a university system with Student, Professor, and Course classes. Students enroll in courses, and professors teach courses. Ensure students and professors can communicate through methods like EnrollCourse() and AssignProfessor().
Goal: Use association and aggregation to create a university system that emphasizes relationships and interactions among students, professors, and courses.
*/

using System;
using System.Collections.Generic;

// Student class
class Student
{
    public string Name { get; set; }
    public int Id { get; set; }
    private List<Course> courses; // A student enrolls in multiple courses

    public Student(string name, int id)
    {
        Name = name;
        Id = id;
        courses = new List<Course>();
    }

    // Method to enroll a student in a course
    public void EnrollCourse(Course course)
    {
        courses.Add(course);
        course.AddStudent(this);
        Console.WriteLine($"{Name} has enrolled in {course.Name}.");
    }

    // Display student details and enrolled courses
    public void DisplayCourses()
    {
        Console.WriteLine($"Student: {Name} (ID: {Id}) is enrolled in:");
        foreach (var course in courses)
        {
            Console.WriteLine($"  - {course.Name}");
        }
    }
}

// Professor class (Aggregation: Professors can exist independently)
class Professor
{
    public string Name { get; set; }
    public string Department { get; set; }
    private List<Course> courses; // A professor teaches multiple courses

    public Professor(string name, string department)
    {
        Name = name;
        Department = department;
        courses = new List<Course>();
    }

    // Assign professor to a course
    public void AssignProfessor(Course course)
    {
        courses.Add(course);
        course.AssignProfessor(this);
        Console.WriteLine($"{Name} is assigned to teach {course.Name}.");
    }

    // Display professor details and assigned courses
    public void DisplayCourses()
    {
        Console.WriteLine($"Professor: {Name} (Department: {Department}) teaches:");
        foreach (var course in courses)
        {
            Console.WriteLine($"  - {course.Name}");
        }
    }
}

// Course class
class Course
{
    public string Name { get; set; }
    private List<Student> students; // Students enrolled in this course
    private Professor professor; // Professor assigned to this course

    public Course(string name)
    {
        Name = name;
        students = new List<Student>();
    }

    // Add a student to the course
    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    // Assign a professor to the course
    public void AssignProfessor(Professor professor)
    {
        this.professor = professor;
    }

    // Display course details
    public void DisplayCourseDetails()
    {
        Console.WriteLine($"Course: {Name}");
        
        Console.WriteLine("  Enrolled Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"    - {student.Name}");
        }

        Console.WriteLine($"  Professor: {(professor != null ? professor.Name : "Not Assigned")}");
    }
}

// Main class
class Program
{
    public static void Main()
    {
        // Creating students
        Student student1 = new Student("Ram", 101);
        Student student2 = new Student("Shyam", 102);

        // Creating professors
        Professor prof1 = new Professor("Dr. Agarwal", "Computer Science");
        Professor prof2 = new Professor("Dr. Dwivedi", "Mathematics");

        // Creating courses
        Course course1 = new Course("Data Structures");
        Course course2 = new Course("Calculus");

        // Students enrolling in courses
        student1.EnrollCourse(course1);
        student2.EnrollCourse(course1);
        student1.EnrollCourse(course2);

        // Assigning professors to courses
        prof1.AssignProfessor(course1);
        prof2.AssignProfessor(course2);

        // Display student enrollments
        Console.WriteLine("\nStudent Enrollments:");
        student1.DisplayCourses();
        student2.DisplayCourses();

        // Display professor assignments
        Console.WriteLine("\nProfessor Assignments:");
        prof1.DisplayCourses();
        prof2.DisplayCourses();

        // Display course details
        Console.WriteLine("\nCourse Details:");
        course1.DisplayCourseDetails();
        course2.DisplayCourseDetails();
    }
}




