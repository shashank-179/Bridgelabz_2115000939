using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static Dictionary<string, int> CountWordFrequency(string text)
    {
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        string[] words = text.ToLower().Split(new char[] { ' ', ',', '!', '.', '?' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }

        return wordCount;
    }

    static void Main()
    {
        string text = "Hello world, hello Java!";
        Dictionary<string, int> result = CountWordFrequency(text);

        foreach (var pair in result)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }
}