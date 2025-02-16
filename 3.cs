/*Problem 1: Concatenate Strings Efficiently Using StringBuilder
Problem: You are given an array of strings. Write a program that uses StringBuilder to concatenate all the strings in the array efficiently.
*/

using System;
using System.Text;


class Program
{
    static void Main()
    {
        string[] words = { "Hello", "World", "C#", "Programming" };
        StringBuilder sb = new StringBuilder();
       
        foreach (string word in words)
        {
            sb.Append(word).Append(" ");
        }


        Console.WriteLine(sb.ToString().Trim());
    }
}
