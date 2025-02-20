/*Filter Streams - Convert Uppercase to Lowercase
 📌 Problem Statement: Create a program that reads a text file and writes its contents into another file, converting all uppercase letters to lowercase. 
Requirements: Use StreamReader and StreamWriter. Use BufferedStream for efficiency. Handle character encoding issues.
*/

using System;
using System.IO;

class UpperLower
{
   public static void ConvertUppercaseToLowercase(string sourcePath, string destinationPath)
   {
       try
       {
           if (!File.Exists(sourcePath))
           {
               Console.WriteLine("Source file does not exist.");
               return;
           }

           using (StreamReader reader = new StreamReader(sourcePath))
           using (StreamWriter writer = new StreamWriter(destinationPath))
           {
               string line;
               while ((line = reader.ReadLine()) != null)
               {
                   writer.WriteLine(line.ToLower());
               }
           }

           Console.WriteLine("Conversion completed successfully.");
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error: " + ex.Message);
       }
   }

   public static void Main(string[] args)
   {
       Console.Write("Enter the source file path: ");
       string sourcePath = Console.ReadLine();

       Console.Write("Enter the destination file path: ");
       string destinationPath = Console.ReadLine();

       ConvertUppercaseToLowercase(sourcePath, destinationPath);
   }
}

