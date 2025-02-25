/*Convert CSV Data into Java Objects
Read a CSV file and convert each row into a Student Java object.
Store the objects in a List<Student> and print them.
*/

using System;
using System.Collections.Generic;
using System.IO;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Marks { get; set; }

    // Constructor
    public Student(int id, string name, int age, double marks)
    {
        Id = id;
        Name = name;
        Age = age;
        Marks = marks;
    }

    // Override ToString for easy printing
    public override string ToString()
    {
        return $"Student [ID={Id}, Name={Name}, Age={Age}, Marks={Marks}]";
    }
}

class CSVToStudent
{
    static void Main()
    {
        string filePath = "students.csv"; // CSV file path
        List<Student> studentList = new List<Student>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                reader.ReadLine(); // Skip header row

                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(','); // Split by comma

                    // Parse fields
                    int id = int.Parse(fields[0].Trim());
                    string name = fields[1].Trim();
                    int age = int.Parse(fields[2].Trim());
                    double marks = double.Parse(fields[3].Trim());

                    // Create Student object and add to list
                    studentList.Add(new Student(id, name, age, marks));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }

        // Print all Student objects
        Console.WriteLine("Student Records:");
        foreach (Student student in studentList)
        {
            Console.WriteLine(student);
        }
    }
}

