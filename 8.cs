/* Validate CSV Data Before Processing
Ensure that the "Email" column follows a valid email format using regex.
Ensure that "Phone Numbers" contain exactly 10 digits.
Print any invalid rows with an error message.
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFile = "contacts.csv"; // CSV file path

        if (File.Exists(inputFile))
        {
            List<string> invalidRows = new List<string>();
            string[] lines = File.ReadAllLines(inputFile);

            // Define regex patterns
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            string phonePattern = @"^\d{10}$";

            Console.WriteLine("Validating CSV Data...\n");

            // Process each row (skip header)
            for (int i = 1; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(',');

                string id = fields[0].Trim();
                string name = fields[1].Trim();
                string email = fields[2].Trim();
                string phone = fields[3].Trim();

                bool isEmailValid = Regex.IsMatch(email, emailPattern);
                bool isPhoneValid = Regex.IsMatch(phone, phonePattern);

                if (!isEmailValid || !isPhoneValid)
                {
                    invalidRows.Add($"Row {i + 1}: {lines[i]}");
                    Console.WriteLine($"❌ Invalid Record (Row {i + 1}): {lines[i]}");
                    if (!isEmailValid)
                        Console.WriteLine("   ➜ Error: Invalid Email Format ❌");
                    if (!isPhoneValid)
                        Console.WriteLine("   ➜ Error: Invalid Phone Number ❌");
                    Console.WriteLine();
                }
            }

            // Summary
            if (invalidRows.Count == 0)
            {
                Console.WriteLine("✅ All records are valid!");
            }
            else
            {
                Console.WriteLine($"⚠️ Found {invalidRows.Count} invalid record(s).");
            }
        }
        else
        {
            Console.WriteLine("File not found!");
        }
    }
}

