/*ByteArray Stream - Convert Image to ByteArray 
📌 Problem Statement: Write a C# program that converts an image file into a byte array and then writes it back to another image file. Requirements: Use MemoryStream to handle byte arrays. Verify that the new file is identical to the original image. Handle IOException.
*/

using System;
using System.IO;

class ByteArray
{
   public static byte[] ImageToByteArray(string imagePath)
   {
       try
       {
           using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
           using (MemoryStream ms = new MemoryStream())
           {
               fs.CopyTo(ms);
               return ms.ToArray();
           }
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error reading the image: " + ex.Message);
           return Array.Empty<byte>();
       }
   }

   public static void ByteArrayToImage(byte[] imageBytes, string outputPath)
   {
       try
       {
           using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
           {
               fs.Write(imageBytes, 0, imageBytes.Length);
           }
           Console.WriteLine("Image successfully written to: " + outputPath);
       }
       catch (IOException ex)
       {
           Console.WriteLine("Error writing the image: " + ex.Message);
       }
   }

   public static void Main(string[] args)
   {
       Console.Write("Enter the source image path: ");
       string sourcePath = Console.ReadLine();

       Console.Write("Enter the destination image path: ");
       string destinationPath = Console.ReadLine();

       byte[] imageBytes = ImageToByteArray(sourcePath);

       if (imageBytes.Length > 0)
       {
           ByteArrayToImage(imageBytes, destinationPath);
       }
   }
}




