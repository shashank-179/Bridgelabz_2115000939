/*Linear Search Problem 1: Search for the First Negative Number
Problem: You are given an integer array. Write a program that performs Linear Search to find the first negative number in the array.
*/

using System;


class Program
{
    static void Main()
    {
        int[] numbers = { 4, 3, -1, 5, -7 };
       
        foreach (int num in numbers)
        {
            if (num < 0)
            {
                Console.WriteLine("First negative number: " + num);
                return;
            }
        }


        Console.WriteLine("No negative numbers found.");
    }
}


