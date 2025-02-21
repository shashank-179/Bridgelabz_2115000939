/*1. Handling File Not Found Exception
💡 Problem Statement:
Create a C# program that reads a file named "data.txt". If the file does not exist, handle the IOException properly and display a user-friendly message.
Expected Behavior:
If the file exists, print its contents.
If the file does not exist, catch the IOException and print "File not found".
*/

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string content = File.ReadAllText("data.txt");
            Console.WriteLine(content);
        }
        catch (IOException)
        {
            Console.WriteLine("File not found");
        }
    }
}



