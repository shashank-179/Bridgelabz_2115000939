/*Multi-Level University Course Management System
Concepts: Generic Classes, Constraints, Variance
Problem Statement: Develop a university course management system where different departments offer courses with different evaluation types.
Hints: 
Create an abstract class CourseType (e.g., ExamCourse, AssignmentCourse).
Implement a generic class Course<T> where T : CourseType to manage different courses.
Use List<T> to handle any type of course dynamically.
*/
using System;
using System.Collections.Generic;

// Abstract class for course types
abstract class CourseType { }

class ExamCourse : CourseType { }
class AssignmentCourse : CourseType { }

// Generic Course class
class Course<T> where T : CourseType
{
    public string Title { get; set; }
    public List<T> Evaluations { get; set; } = new List<T>();
}

// Main execution
class Program
{
    static void Main()
    {
        Course<ExamCourse> mathCourse = new Course<ExamCourse> { Title = "Mathematics 101" };
        Course<AssignmentCourse> programmingCourse = new Course<AssignmentCourse> { Title = "C# Programming" };

        Console.WriteLine($"Course Created: {mathCourse.Title}");
        Console.WriteLine($"Course Created: {programmingCourse.Title}");
    }
}




