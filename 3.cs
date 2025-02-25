/*Read and Count Rows in a CSV File
Read a CSV file and count the number of records (excluding the header row).
*/
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "data.csv"; // Path to the CSV file

        if (File.Exists(filePath))
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                bool isHeader = true;
                while (reader.ReadLine() != null)
                {
                    if (isHeader) 
                    { 
                        isHeader = false; 
                        continue; // Skip header row
                    }
                    count++;
                }
            }

            Console.WriteLine($"Total number of records (excluding header): {count}");
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}

