/*Problem 1: Convert Byte Stream to Character Stream Using StreamReader
Problem: Write a program that uses StreamReader to read binary data from a file and print it as characters.
*/

using System;
using System.IO;
using System.Text;


class Program
{
    static void Main()
    {
        string filePath = "binaryfile.bin";
       
        if (File.Exists(filePath))
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
