/*Merge Two CSV Files
You have two CSV files:
students1.csv (contains ID, Name, Age)
students2.csv (contains ID, Marks, Grade)
Merge both files based on ID and create a new file containing all details.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Marks { get; set; }
    public string Grade { get; set; }

    // Constructor
    public Student(int id, string name, int age, double marks, string grade)
    {
        Id = id;
        Name = name;
        Age = age;
        Marks = marks;
        Grade = grade;
    }

    // Format as CSV row
    public string ToCsv()
    {
        return $"{Id},{Name},{Age},{Marks},{Grade}";
    }
}

class CSVFileMerger
{
    static void Main()
    {
        string file1 = "students1.csv";
        string file2 = "students2.csv";
        string outputFile = "merged_students.csv";

        Dictionary<int, (string Name, int Age)> studentInfo = new Dictionary<int, (string, int)>();
        Dictionary<int, (double Marks, string Grade)> studentScores = new Dictionary<int, (double, string)>();

        try
        {
            // Read students1.csv (ID, Name, Age)
            using (StreamReader reader = new StreamReader(file1))
            {
                reader.ReadLine(); // Skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    int id = int.Parse(fields[0].Trim());
                    string name = fields[1].Trim();
                    int age = int.Parse(fields[2].Trim());
                    studentInfo[id] = (name, age);
                }
            }

            // Read students2.csv (ID, Marks, Grade)
            using (StreamReader reader = new StreamReader(file2))
            {
                reader.ReadLine(); // Skip header
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');
                    int id = int.Parse(fields[0].Trim());
                    double marks = double.Parse(fields[1].Trim());
                    string grade = fields[2].Trim();
                    studentScores[id] = (marks, grade);
                }
            }

            // Merge Data
            List<Student> mergedStudents = new List<Student>();
            foreach (var entry in studentInfo)
            {
                int id = entry.Key;
                string name = entry.Value.Name;
                int age = entry.Value.Age;

                if (studentScores.ContainsKey(id))
                {
                    double marks = studentScores[id].Marks;
                    string grade = studentScores[id].Grade;
                    mergedStudents.Add(new Student(id, name, age, marks, grade));
                }
            }

            // Write merged data to new CSV file
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                writer.WriteLine("ID,Name,Age,Marks,Grade");
                foreach (var student in mergedStudents)
                {
                    writer.WriteLine(student.ToCsv());
                }
            }

            Console.WriteLine($"Merged data successfully written to {outputFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing files: " + ex.Message);
        }
    }
}

