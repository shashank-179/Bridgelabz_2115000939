/*5. Using using Statement for File Handling
💡 Problem Statement:
Write a C# program that reads the first line of a file named "info.txt" using StreamReader.
Use using to ensure the file is automatically closed after reading.
Handle any IOException that may occur.
Expected Behavior:
If the file exists, print its first line.
If the file does not exist, catch IOException and print "Error reading file".
*/
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            using (StreamReader sr = new StreamReader("info.txt"))
            {
                Console.WriteLine(sr.ReadLine());
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Error reading file");
        }
    }
}



