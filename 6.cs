/*Problem 2: Count the Occurrence of a Word in a File Using StreamReader
Problem: Write a program that reads a file and counts how many times a specific word appears in the file.
*/

using System;
using System.IO;


class Program
{
    static void Main()
    {
        string filePath = "sample.txt"; // Ensure this file exists
        string wordToFind = "hello";
        int count = 0;


        // Check if file exists before trying to read
        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');
                    foreach (string word in words)
                    {
                        if (word.Equals(wordToFind, StringComparison.OrdinalIgnoreCase))
                        {
                            count++;
                        }
                    }
                }
            }


            Console.WriteLine("Occurrences of '" + wordToFind + "': " + count);
        }
        else
        {
            Console.WriteLine("File not found. Please check the file path.");
        }
    }
}


