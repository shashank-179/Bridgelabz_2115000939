/*Binary Search Problem 1: Find the Rotation Point in a Rotated Sorted Array
Problem: You are given a rotated sorted array. Write a program that performs Binary Search to find the index of the smallest element in the array.
*/

using System;


class Program
{
    static int FindRotationPoint(int[] arr)
    {
        int left = 0, right = arr.Length - 1;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (arr[mid] > arr[right])
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }


    static void Main()
    {
        int[] arr = { 4, 5, 6, 7, 1, 2, 3 };
        Console.WriteLine("Rotation point index: " + FindRotationPoint(arr));
    }
}


