/*StringBuilder Problem 1: Reverse a String Using StringBuilder
Problem: Write a program that uses StringBuilder to reverse a given string. For example, if the input is "hello", the output should be "olleh".
*/

using System;
using System.Text;


class Program
{
    static void Main()
    {
        string input = "hello";
        StringBuilder sb = new StringBuilder(input);
        for (int i = 0, j = input.Length - 1; i < j; i++, j--)
        {
            char temp = sb[i];
            sb[i] = sb[j];
            sb[j] = temp;
        }
        Console.WriteLine(sb.ToString());
    }
}


