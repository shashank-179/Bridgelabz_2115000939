/*Encrypt and Decrypt CSV Data
Encrypt the sensitive fields (e.g., Salary, Email) while writing to a CSV file.
Decrypt them when reading the file.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }  // Encrypted
    public string Department { get; set; }
    public string Salary { get; set; } // Encrypted
}

class Program
{
    static readonly string encryptionKey = "MySecretKey12345"; // 16-char key for AES

    static void Main()
    {
        string csvFile = "employees_encrypted.csv";

        List<Employee> employees = new List<Employee>
        {
            new Employee { ID = 1, Name = "Alice", Email = "alice@example.com", Department = "IT", Salary = "60000" },
            new Employee { ID = 2, Name = "Bob", Email = "bob@example.com", Department = "HR", Salary = "50000" }
        };

        // Encrypt and Write Data to CSV
        WriteEncryptedCsv(csvFile, employees);
        Console.WriteLine("✅ Encrypted CSV file created.");

        // Read and Decrypt Data from CSV
        List<Employee> decryptedEmployees = ReadDecryptedCsv(csvFile);
        Console.WriteLine("\n✅ Decrypted Employee Data:");
        foreach (var emp in decryptedEmployees)
        {
            Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}, Email: {emp.Email}, Department: {emp.Department}, Salary: {emp.Salary}");
        }
    }

    // Method to write encrypted data to CSV
    static void WriteEncryptedCsv(string filePath, List<Employee> employees)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("ID,Name,Email,Department,Salary");

            foreach (var emp in employees)
            {
                string encryptedEmail = Encrypt(emp.Email);
                string encryptedSalary = Encrypt(emp.Salary);
                writer.WriteLine($"{emp.ID},{emp.Name},{encryptedEmail},{emp.Department},{encryptedSalary}");
            }
        }
    }

    // Method to read and decrypt data from CSV
    static List<Employee> ReadDecryptedCsv(string filePath)
    {
        List<Employee> employees = new List<Employee>();
        string[] lines = File.ReadAllLines(filePath);

        for (int i = 1; i < lines.Length; i++) // Skip header
        {
            string[] data = lines[i].Split(',');

            employees.Add(new Employee
            {
                ID = int.Parse(data[0]),
                Name = data[1],
                Email = Decrypt(data[2]),
                Department = data[3],
                Salary = Decrypt(data[4])
            });
        }

        return employees;
    }

    // AES Encryption
    static string Encrypt(string text)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
            aes.IV = new byte[16]; // Default IV (all zeros)

            using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(text);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }

    // AES Decryption
    static string Decrypt(string cipherText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(encryptionKey);
            aes.IV = new byte[16];

            using (ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}



