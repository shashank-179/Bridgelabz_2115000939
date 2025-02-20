/* Problem Statement: Write a C# program that reads the contents of a text file and writes it into a new file. If the source file does not exist, display an appropriate message. 
Requirements: Use FileStream for reading and writing. Handle IOException properly. Ensure that the destination file is created if it does not exist.
*/

using System;
using System.IO;
class FileHandling
{
public static void CopyFile(string sourcePath, string destinationPath)
{
try
{
if (!File.Exists(sourcePath))
{
Console.WriteLine("Source file does not exist.");
return;
}
using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
{
using (FileStream destStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
{
byte[] buffer = new byte[1024];
int bytesRead;
while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
{
destStream.Write(buffer, 0, bytesRead);
}
Console.WriteLine("File copied successfully!");
}
}
}
catch (IOException ex)
{
Console.WriteLine("An error occurred: " + ex.Message);
}
}
public static void Main(string[] args)
{
Console.Write("Enter source file path: ");
string sourcePath = Console.ReadLine();
Console.Write("Enter destination file path: ");
string destinationPath = Console.ReadLine();
CopyFile(sourcePath, destinationPath);
}
} 

