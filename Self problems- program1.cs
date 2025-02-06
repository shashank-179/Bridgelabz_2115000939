/*Problem 1: School and Students with Courses (Association and Aggregation)
Description: Model a School with multiple Student objects, where each student can enroll in multiple courses, and each course can have multiple students.
Tasks:
Define School, Student, and Course classes.
Model an association between Student and Course to show that students can enroll in multiple courses.
Model an aggregation relationship between School and Student.
Demonstrate how a student can view the courses they are enrolled in and how a course can show its enrolled students.
Goal: Practice association by modeling many-to-many relationships between students and courses.
*/
using System;
using System.Collections.Generic;

class Student
{
    public string name;
    public int rollno { get; set; }

    public Student(string name, int rollno)
    {
        this.name = name;
        this.rollno = rollno;
    }

    public void display() // Show student details
    {
        Console.WriteLine($"  Name: {name}, Roll Number: {rollno}");
    }
}

class Course
{
    public string name;
    private List<Student> students;

    public Course(string name)
    {
        this.name = name;
        students = new List<Student>();
    }

    public void enroll(Student student) // Add student
    {
        students.Add(student);
    }

    public void display() // Show course details
    {
        Console.WriteLine($"Course: {name}");
        if (students.Count > 0)
        {
            Console.WriteLine("  Students enrolled:");
            foreach (Student student in students)
            {
                student.display();
            }
        }
        else
        {
            Console.WriteLine("  No students enrolled");
        }
    }
}

class School
{
    public string name;
    private List<Course> courses;

    public School(string name)
    {
        this.name = name;
        courses = new List<Course>();
    }

    public void addCourse(Course course) // Add course
    {
        courses.Add(course);
    }

    public void display() // Show school details
    {
        Console.WriteLine($"School: {name}");
        if (courses.Count > 0)
        {
            Console.WriteLine("Courses offered:");
            foreach (Course course in courses)
            {
                course.display();
            }
        }
        else
        {
            Console.WriteLine("No courses available.");
        }
    }

    public static void Main()
    {
        Student s1 = new Student("Ram", 1);
        Student s2 = new Student("Shyam", 2);
        Student s3 = new Student("Arun", 3);
        Student s4 = new Student("Varun", 4);
        Student s5 = new Student("Vikram", 5);

        Course phy = new Course("Physics");
        Course math = new Course("Mathematics");

        School s = new School("City Montessori School");

        phy.enroll(s1);
        phy.enroll(s2);
        phy.enroll(s3);
        math.enroll(s4);
        math.enroll(s5);
        math.enroll(s2);
        s.addCourse(phy);
        s.addCourse(math);

        s.display();
        s1.display();
    }
}


