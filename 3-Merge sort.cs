/*3. Merge Sort - Sort an Array of Book Prices
Problem Statement:
A bookstore maintains a list of book prices in an array. Implement Merge Sort in C# to sort the prices in ascending order.
Hint:
Divide the array into two halves recursively.
Sort both halves individually.
Merge the sorted halves by comparing elements.
*/

using System;

class MergeSort
{
    // Merge two sorted subarrays
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;  // Size of left subarray
        int n2 = right - mid;      // Size of right subarray

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        // Copy data to temporary arrays
        for (int i = 0; i < n1; i++)
            leftArray[i] = arr[left + i];
        for (int j = 0; j < n2; j++)
            rightArray[j] = arr[mid + 1 + j];

        int i1 = 0, i2 = 0, k = left;

        // Merge the two subarrays back into arr[]
        while (i1 < n1 && i2 < n2)
        {
            if (leftArray[i1] <= rightArray[i2])
                arr[k++] = leftArray[i1++];
            else
                arr[k++] = rightArray[i2++];
        }

        // Copy remaining elements of leftArray[], if any
        while (i1 < n1)
            arr[k++] = leftArray[i1++];

        // Copy remaining elements of rightArray[], if any
        while (i2 < n2)
            arr[k++] = rightArray[i2++];
    }

    // Recursive Merge Sort function
    static void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2; // Find the middle index

            // Recursively sort first and second halves
            Sort(arr, left, mid);
            Sort(arr, mid + 1, right);

            // Merge the sorted halves
            Merge(arr, left, mid, right);
        }
    }

    public static void Main()
    {
        Console.WriteLine("Enter number of books:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] prices = new int[n];

        Console.WriteLine($"Enter {n} book prices:");
        for (int i = 0; i < n; i++)
        {
            prices[i] = Convert.ToInt32(Console.ReadLine());
        }

        Sort(prices, 0, n - 1); // Sort the array

        Console.WriteLine("Sorted book prices:");
        foreach (int price in prices)
        {
            Console.Write(price + " ");
        }
    }
}


