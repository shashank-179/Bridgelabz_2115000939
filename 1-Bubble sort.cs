/*1. Bubble Sort - Sort Student Marks
Problem Statement:
A school maintains student marks in an array. Implement Bubble Sort in C# to sort the student marks in ascending order.
Hint:
Traverse through the array multiple times.
Compare adjacent elements and swap them if needed.
Repeat the process until no swaps are required.

*/
using System;

class Bubble
{
    public static void Sort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)  
            {
                if (arr[j] > arr[j + 1])  //  Swap if needed
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }
    }

    public static void Main()
    {
        Console.WriteLine("Enter size of array:");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];

        Console.WriteLine($"Enter {n} student marks:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Sort(arr); // Sorting the array

        Console.WriteLine("Sorted marks:");
        foreach (int mark in arr)
        {
            Console.Write(mark + " ");
        }
    }
}

