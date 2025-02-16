/*Binary Search Problem 4: Find the First and Last Occurrence of an Element in a Sorted Array
Problem: Given a sorted array and a target element, write a program that uses Binary Search to find the first and last occurrence of the target element in the array.
*/

using System;


class Program
{
    static int FindFirst(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1, result = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                result = mid;
                right = mid - 1;
            }
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return result;
    }


    static int FindLast(int[] arr, int target)
    {
        int left = 0, right = arr.Length - 1, result = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] == target)
            {
                result = mid;
                left = mid + 1;
            }
            else if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return result;
    }


    static void Main()
    {
        int[] arr = { 1, 2, 2, 2, 3, 4, 5 };
        int target = 2;
        Console.WriteLine("First occurrence: " + FindFirst(arr, target));
        Console.WriteLine("Last occurrence: " + FindLast(arr, target));
    }
}


