/*Linear Search Problem 2: Search for a Specific Word in a List of Sentences
Problem: You are given an array of sentences. Write a program that performs Linear Search to find the first sentence containing a specific word.
*/

using System;


class Program
{
    static void Main()
    {
        string[] sentences = { "Hello world", "Programming in C#", "Welcome to coding" };
        string wordToFind = "C#";


        foreach (string sentence in sentences)
        {
            if (sentence.Contains(wordToFind))
            {
                Console.WriteLine("Found in: " + sentence);
                return;
            }
        }


        Console.WriteLine("Word not found.");
    }
}


