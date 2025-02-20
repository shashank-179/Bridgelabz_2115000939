/*Read a Large File Line by Line
 📌 Problem Statement: Develop a C# program that efficiently reads a large text file (500MB+) line by line and prints only lines containing the word "error". 
Requirements: Use StreamReader for efficient reading. Read line-by-line instead of loading the entire file. Display only lines containing "error" (case insensitive).
*/

using System;
using System.IO;

class LargeFile
{
   public static void ReadErrorLines(string filePath)
   {
       try
       {
           using (StreamReader reader = new StreamReader(filePath))
           {
               string line;
               while ((line = reader.ReadLine()) != null)
               {
                   if (line.IndexOf("error", StringComparison.OrdinalIgnoreCase) >= 0)
                   {
                       Console.WriteLine(line);
                   }
               }
           }
       }
       catch (IOException ex)
       {
           Console.WriteLine("File read error: " + ex.Message);
       }
   }

   public static void Main(string[] args)
   {
       Console.Write("Enter the file path: ");
       string filePath = Console.ReadLine();

       if (File.Exists(filePath))
       {
           ReadErrorLines(filePath);
       }
       else
       {
           Console.WriteLine("File does not exist.");
       }
   }
}



