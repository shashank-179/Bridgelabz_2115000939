/*Detect Duplicates in a CSV File
Read a CSV file and detect duplicate entries based on the ID column.
Print all duplicate records.
*/
using System;
using System.Collections.Generic;
using System.IO;

class CSVDuplicateChecker
{
    static void Main()
    {
        string filePath = "students.csv"; // Update with the actual CSV file path
        Dictionary<string, List<string>> recordMap = new Dictionary<string, List<string>>();
        HashSet<string> duplicateIds = new HashSet<string>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string? header = reader.ReadLine(); // Read and skip the header
                Console.WriteLine("Checking for duplicate entries...\n");

                while (!reader.EndOfStream)
                {
                    string? line = reader.ReadLine();
                    if (line == null) continue;

                    string[] columns = line.Split(','); // Assuming CSV is comma-separated
                    string id = columns[0]; // ID column

                    if (recordMap.ContainsKey(id))
                    {
                        duplicateIds.Add(id);
                        recordMap[id].Add(line);
                    }
                    else
                    {
                        recordMap[id] = new List<string> { line };
                    }
                }
            }

            // Print duplicate records
            if (duplicateIds.Count > 0)
            {
                Console.WriteLine("🚨 Duplicate Records Found:");
                foreach (var id in duplicateIds)
                {
                    foreach (var record in recordMap[id])
                    {
                        Console.WriteLine(record);
                    }
                }
            }
            else
            {
                Console.WriteLine("✅ No duplicate records found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

