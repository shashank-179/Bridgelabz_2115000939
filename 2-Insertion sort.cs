/*2. Insertion Sort - Sort Employee IDs
Problem Statement:
A company stores employee IDs in an unsorted array. Implement Insertion Sort in C# to sort the employee IDs in ascending order.
Hint:
Divide the array into sorted and unsorted parts.
Pick an element from the unsorted part and insert it into its correct position in the sorted part.
Repeat for all elements.
*/

using System;

class Insertion
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }


    public static void Main()
    {
        Console.WriteLine("Enter size of array:");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];

        Console.WriteLine($"Enter {n} employee ids:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Sort(arr); // Sorting the array

        Console.WriteLine("Sorted employee ids:");
        foreach (int id in arr)
        {
            Console.Write(id + " ");
        }
    }
}

