/*Problem 2: Read User Input and Write to File Using StreamReader
Problem: Write a program that reads user input from the console and writes it to a file.
*/

using System;
using System.IO;


class Program
{
    static void Main()
    {
        Console.WriteLine("Enter text to save:");
        string input = Console.ReadLine();


        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            writer.WriteLine(input);
        }


        Console.WriteLine("Text saved to file.");
    }
}


