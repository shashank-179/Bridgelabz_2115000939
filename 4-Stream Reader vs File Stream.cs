/*4. Large File Reading Efficiency
Objective
Compare StreamReader and FileStream when reading a large file (500MB).
Approach
StreamReader: Reads character by character (slower for binary files).
FileStream: Reads bytes and converts to characters (more efficient).
File Size
StreamReader Time
FileStream Time
1MB
50ms
30ms
100MB
3s
1.5s
500MB
10s
5s

Expected Result
FileStream is more efficient for large files. StreamReader is preferable for text-based data.
*/

using System;
using System.Diagnostics;
using System.IO;

class FileReadComparison
{
    // Method to generate a large text file (500MB)
    static void GenerateLargeFile(string filePath, long fileSizeInMB)
    {
        const string sampleText = "A quick brown fox jumps over the lazy dog.\n";  // Sample text to write
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            long totalBytesWritten = 0;
            while (totalBytesWritten < fileSizeInMB * 1024 * 1024)
            {
                writer.Write(sampleText);  // Write the sample text repeatedly
                totalBytesWritten += sampleText.Length;
            }
        }
        Console.WriteLine("Large file generated successfully.");
    }

    // Concatenate N strings using String (O(N²)) - immutable
    static void ConcatenateWithString(int N)
    {
        string result = "";
        for (int i = 0; i < N; i++)
        {
            result += "A"; // Concatenating using string
        }
    }

    // Concatenate N strings using StringBuilder (O(N)) - mutable
    static void ConcatenateWithStringBuilder(int N)
    {
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < N; i++)
        {
            sb.Append("A"); // Concatenating using StringBuilder
        }
    }

    // Measure concatenation time for each method
    static void MeasureConcatenationTime(Action<int> concatMethod, int N, string name)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        concatMethod(N); // Execute the method
        stopwatch.Stop();
        Console.WriteLine($"{name} Time for {N} concatenations: {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    // Method to measure the time taken by StreamReader
    static void ReadWithStreamReader(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                // Read the file line by line (this is a slow operation for large files)
            }
        }
    }

    // Method to measure the time taken by FileStream
    static void ReadWithFileStream(string filePath)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[8192];  // Read in chunks of 8KB
            int bytesRead;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                // Read the file in binary mode (much faster for large files)
            }
        }
    }

    // Measure file reading time
    static void MeasureFileReadTime(Action<string> readMethod, string filePath, string methodName)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        readMethod(filePath); // Execute the file reading method
        stopwatch.Stop();
        Console.WriteLine($"{methodName} Time: {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    static void Main()
    {
        string filePath = "largeFile.txt";  // Path for the generated file
        long fileSizeInMB = 500;  // Size of the file to generate (500MB)

        // Generate the large file
        GenerateLargeFile(filePath, fileSizeInMB);

        // Measure file reading performance using StreamReader and FileStream
        MeasureFileReadTime(ReadWithStreamReader, filePath, "StreamReader");
        MeasureFileReadTime(ReadWithFileStream, filePath, "FileStream");
    }
}

