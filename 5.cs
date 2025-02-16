/*Problem 1: Read a File Line by Line Using StreamReader
Problem: Write a program that uses StreamReader to read a text file line by line and print each line to the console.
*/

using System;
using System.IO;


class Program
{
    static void Main()
    {
        string filePath = "sample.txt";


        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        else
        {
            Console.WriteLine("File not found. Please check the file path.");
        }
    }
}
