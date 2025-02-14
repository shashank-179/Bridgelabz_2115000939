/*Heap Sort - Sort Job Applicants by Salary
Problem Statement:
A company receives job applications with different expected salary demands. Implement Heap Sort in C# to sort these salary demands in ascending order.
Hint:
Build a Max Heap from the array.
Extract the largest element (root) and place it at the end.
Reheapify the remaining elements and repeat until sorted.
*/

using System;

class HeapSort
{
    // Function to heapify a subtree rooted at index 'i'
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i; // Root (parent node)
        int left = 2 * i + 1; // Left child
        int right = 2 * i + 2; // Right child

        // If left child is larger than root
        if (left < n && arr[left] > arr[largest])
            largest = left;

        // If right child is larger than largest so far
        if (right < n && arr[right] > arr[largest])
            largest = right;

        // If largest is not root, swap and continue heapifying
        if (largest != i)
        {
            (arr[i], arr[largest]) = (arr[largest], arr[i]);
            Heapify(arr, n, largest);
        }
    }

    // Main function to perform Heap Sort
    static void Sort(int[] arr)
    {
        int n = arr.Length;

        // Build a max heap (rearrange array)
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // Extract elements one by one from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            (arr[0], arr[i]) = (arr[i], arr[0]);

            // Call heapify on the reduced heap
            Heapify(arr, i, 0);
        }
    }

    public static void Main()
    {
        Console.WriteLine("Enter number of job applicants:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] salaries = new int[n];

        Console.WriteLine($"Enter {n} salary demands:");
        for (int i = 0; i < n; i++)
        {
            salaries[i] = Convert.ToInt32(Console.ReadLine());
        }

        Sort(salaries); // Apply Heap Sort

        Console.WriteLine("Sorted salary demands:");
        foreach (int salary in salaries)
        {
            Console.Write(salary + " ");
        }
    }
}



