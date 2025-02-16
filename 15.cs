/*Challenge Problem (for both Linear and Binary Search)

Problem:
You are given a list of integers. Write a program that uses Linear Search to find the first missing positive integer in the list and Binary Search to find the index of a given target number.
Approach:
Linear Search for the first missing positive integer:
Iterate through the list and mark each number in the list as visited (you can use negative marking or a separate array).
Traverse the array again to find the first positive integer that is not marked.
Binary Search for the target index:
After sorting the array, perform binary search to find the index of the given target number.
Return the index if found, otherwise return -1.
*/

using System;


class Program
{
    // Function to find the first missing positive integer using Linear Search
    static int FindFirstMissingPositive(int[] nums)
    {
        int n = nums.Length;


        // Step 1: Place numbers in their correct index position
        for (int i = 0; i < n; i++)
        {
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
            {
                // Swap nums[i] with nums[nums[i] - 1]
                int temp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
            }
        }


        // Step 2: Find the first missing positive number
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != i + 1)
                return i + 1;
        }


        return n + 1;
    }


    // Function to perform Binary Search
    static int BinarySearch(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;


        while (left <= right)
        {
            int mid = left + (right - left) / 2;


            if (nums[mid] == target)
                return mid; // Target found, return index
            else if (nums[mid] < target)
                left = mid + 1; // Search in right half
            else
                right = mid - 1; // Search in left half
        }


        return -1; // Target not found
    }


    static void Main()
    {
        int[] nums = { 3, 4, -1, 1 };
        int target = 4;


        // Finding the first missing positive integer
        int missingPositive = FindFirstMissingPositive((int[])nums.Clone());
        Console.WriteLine("First Missing Positive Integer: " + missingPositive);


        // Sorting array before Binary Search
        Array.Sort(nums);


        // Finding the target using Binary Search
        int index = BinarySearch(nums, target);
        Console.WriteLine(index != -1 ? $"Target {target} found at index {index}" : "Target not found");
    }
}



