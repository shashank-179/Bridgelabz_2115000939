/*Buffered Streams - Efficient File Copy 
📌 Problem Statement: Create a C# program that copies a large file (e.g., 100MB) from one location to another using Buffered Streams (BufferedStream). Compare the performance with normal file streams. 
Requirements: Read and write in chunks of 4 KB (4096 bytes). Use Stopwatch to measure execution time. Compare execution time with unbuffered streams.
*/
using System;
using System.Diagnostics;
using System.IO;

class FileCopy
{
   public static void CopyWithBufferedStream(string sourcePath, string destinationPath)
   {
       try
       {
           if (!File.Exists(sourcePath))
           {
               Console.WriteLine("Source file does not exist.");
               return;
           }

           Stopwatch stopwatch = Stopwatch.StartNew();

           using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
           using (FileStream destStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
           using (BufferedStream bufferedStream = new BufferedStream(sourceStream, 4096))
           {
               byte[] buffer = new byte[4096];
               int bytesRead;

               while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
               {
                   destStream.Write(buffer, 0, bytesRead);
               }
           }

           stopwatch.Stop();
           Console.WriteLine("BufferedStream copy completed in: " + stopwatch.ElapsedMilliseconds + " ms");
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error: " + ex.Message);
       }
   }

   public static void CopyWithFileStream(string sourcePath, string destinationPath)
   {
       try
       {
           if (!File.Exists(sourcePath))
           {
               Console.WriteLine("Source file does not exist.");
               return;
           }

           Stopwatch stopwatch = Stopwatch.StartNew();

           using (FileStream sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
           using (FileStream destStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
           {
               byte[] buffer = new byte[4096];
               int bytesRead;

               while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
               {
                   destStream.Write(buffer, 0, bytesRead);
               }
           }

           stopwatch.Stop();
           Console.WriteLine("FileStream copy completed in: " + stopwatch.ElapsedMilliseconds + " ms");
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error: " + ex.Message);
       }
   }

   public static void Main(string[] args)
   {
       Console.Write("Enter source file path: ");
       string sourcePath = Console.ReadLine();

       Console.Write("Enter destination path for BufferedStream copy: ");
       string bufferedDestPath = Console.ReadLine();

       Console.Write("Enter destination path for FileStream copy: ");
       string fileStreamDestPath = Console.ReadLine();

       CopyWithBufferedStream(sourcePath, bufferedDestPath);
       CopyWithFileStream(sourcePath, fileStreamDestPath);
   }
}



