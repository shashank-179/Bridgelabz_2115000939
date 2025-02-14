/*4. Quick Sort - Sort Product Prices
Problem Statement:
An e-commerce company wants to display product prices in ascending order. Implement Quick Sort in C# to sort the product prices.
Hint:
Pick a pivot element (first, last, or random).
Partition the array such that elements smaller than the pivot are on the left and larger ones are on the right.
Recursively apply Quick Sort on left and right partitions.
*/

using System;

class QuickSort
{
    // Partition function: Places pivot at the correct position
    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high]; // Choosing the last element as pivot
        int i = low - 1; // Index for smaller elements

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot) // If current element is smaller than pivot
            {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]); // Swap
            }
        }

        // Place pivot in its correct position
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);

        return i + 1; // Return pivot index
    }

    // Quick Sort function
    static void Sort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high); // Get pivot index

            Sort(arr, low, pivotIndex - 1); // Sort left partition
            Sort(arr, pivotIndex + 1, high); // Sort right partition
        }
    }

    public static void Main()
    {
        Console.WriteLine("Enter number of products:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] prices = new int[n];

        Console.WriteLine($"Enter {n} product prices:");
        for (int i = 0; i < n; i++)
        {
            prices[i] = Convert.ToInt32(Console.ReadLine());
        }

        Sort(prices, 0, n - 1); // Apply Quick Sort

        Console.WriteLine("Sorted product prices:");
        foreach (int price in prices)
        {
            Console.Write(price + " ");
        }
    }
}

