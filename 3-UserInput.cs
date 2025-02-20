/*Read User Input from Console 
📌 Problem Statement: Write a program that asks the user for their name, age, and favorite programming language, then saves this information into a file. 
Requirements: Use StreamReader for console input. Use StreamWriter to write the data into a file. Handle exceptions properly.
*/
using System;
using System.IO;

class UserInputToFile
{
   public static void Main(string[] args)
   {
       try
       {
           Console.Write("Enter your name: ");
           string name;
           using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
           {
               name = reader.ReadLine();
           }

           Console.Write("Enter your age: ");
           string age;
           using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
           {
               age = reader.ReadLine();
           }

           Console.Write("Enter your favorite programming language: ");
           string language;
           using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
           {
               language = reader.ReadLine();
           }

           using (StreamWriter writer = new StreamWriter("user_data.txt"))
           {
               writer.WriteLine("Name: " + name);
               writer.WriteLine("Age: " + age);
               writer.WriteLine("Favorite Programming Language: " + language);
           }

           Console.WriteLine("Data successfully written to user_data.txt");
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error: " + ex.Message);
       }
   }
}

