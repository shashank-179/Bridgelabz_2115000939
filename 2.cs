/*StringBuilder Problem 2: Remove Duplicates from a String Using StringBuilder
Problem: Write a program that uses StringBuilder to remove all duplicate characters from a given string while maintaining the original order.
*/

using System;
using System.Text;


class Program
{
    static void Main()
    {
        string input = "programming";
        StringBuilder sb = new StringBuilder();


        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];
            bool isDuplicate = false;


            // Check if the character already exists in sb
            for (int j = 0; j < sb.Length; j++)
            {
                if (sb[j] == currentChar)
                {
                    isDuplicate = true;
                    break;
                }
            }


            // Append only if it's not a duplicate
            if (!isDuplicate)
            {
                sb.Append(currentChar);
            }
        }


        Console.WriteLine(sb.ToString());
    }
}


