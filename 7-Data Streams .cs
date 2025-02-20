/*Data Streams - Store and Retrieve Primitive Data 
📌 Problem Statement: Write a C# program that stores student details (roll number, name, GPA) in a binary file and retrieves it later. 
Requirements: Use BinaryWriter to write primitive data. Use BinaryReader to read data. Ensure proper closing of resources.
*/

using System;
using System.IO;

class StudentData
{
   public static void SaveStudentData(string filePath, int rollNumber, string name, float gpa)
   {
       try
       {
           using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
           using (BinaryWriter writer = new BinaryWriter(fs))
           {
               writer.Write(rollNumber);
               writer.Write(name);
               writer.Write(gpa);
           }
           Console.WriteLine("Student data saved successfully.");
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error: " + ex.Message);
       }
   }

   public static void ReadStudentData(string filePath)
   {
       try
       {
           if (!File.Exists(filePath))
           {
               Console.WriteLine("File does not exist.");
               return;
           }

           using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
           using (BinaryReader reader = new BinaryReader(fs))
           {
               int rollNumber = reader.ReadInt32();
               string name = reader.ReadString();
               float gpa = reader.ReadSingle();

               Console.WriteLine("Roll Number: " + rollNumber);
               Console.WriteLine("Name: " + name);
               Console.WriteLine("GPA: " + gpa);
           }
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error: " + ex.Message);
       }
   }

   public static void Main(string[] args)
   {
       string filePath = "student_data.dat";

       Console.Write("Enter roll number: ");
       int rollNumber = int.Parse(Console.ReadLine());

       Console.Write("Enter name: ");
       string name = Console.ReadLine();

       Console.Write("Enter GPA: ");
       float gpa = float.Parse(Console.ReadLine());

       SaveStudentData(filePath, rollNumber, name, gpa);
       ReadStudentData(filePath);
   }
}

