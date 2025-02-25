/* Read Large CSV File Efficiently
Given a large CSV file (500MB+), implement a memory-efficient way to read it in chunks.
Process only 100 lines at a time and display the count of records processed.
*/
using System;
using System.IO;

class LargeCSVReader
{
    static void Main()
    {
        string filePath = "large_data.csv"; // Update with the actual file path
        int batchSize = 100; // Read 100 lines at a time
        int totalRecords = 0;

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string? header = reader.ReadLine(); // Read and skip the header
                Console.WriteLine("Processing file in chunks...");

                while (!reader.EndOfStream)
                {
                    int count = 0;
                    while (count < batchSize && !reader.EndOfStream)
                    {
                        string? line = reader.ReadLine();
                        if (line != null)
                        {
                            totalRecords++;
                            count++;
                        }
                    }
                    Console.WriteLine($"Processed {totalRecords} records so far...");
                }
            }

            Console.WriteLine($"✅ Finished processing. Total records: {totalRecords}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

