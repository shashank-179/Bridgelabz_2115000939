/*Count Words in a File 
📌 Problem Statement: Write a C# program that counts the number of words in a given text file and displays the top 5 most frequently occurring words. 
Requirements: Use StreamReader to read the file. Use a Dictionary<string, int> to count word occurrences. Sort the words based on frequency and display the top 5.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class WordCounter
{
    public static void CountWords(string filePath)
    {
        try
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    foreach (var word in Regex.Matches(line, "\\w+").Cast<Match>().Select(m => m.Value))
                    {
                        if (wordCount.ContainsKey(word))
                        {
                            wordCount[word]++;
                        }
                        else
                        {
                            wordCount[word] = 1;
                        }
                    }
                }
            }

            Console.WriteLine("Total Words: " + wordCount.Values.Sum());

            var top5Words = wordCount.OrderByDescending(kv => kv.Value).Take(5);
            Console.WriteLine("Top 5 Most Frequent Words:");
            foreach (var word in top5Words)
            {
                Console.WriteLine($"{word.Key}: {word.Value}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("File read error: " + ex.Message);
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter the file path: ");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            CountWords(filePath);
        }
        else
        {
            Console.WriteLine("File does not exist.");
        }
    }
}



