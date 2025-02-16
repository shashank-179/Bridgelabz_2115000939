/*Binary Search Problem 2: Find the Peak Element in an Array
Problem: A peak element is an element that is greater than its neighbors. Write a program that performs Binary Search to find a peak element in an array.
*/

using System;


class Program
{
    static int FindPeakElement(int[] nums)
    {
        int left = 0, right = nums.Length - 1;


        while (left < right)
        {
            int mid = left + (right - left) / 2;
           
            if (nums[mid] > nums[mid + 1])
                right = mid;  // Peak is on the left side
            else
                left = mid + 1; // Peak is on the right side
        }


        return left; // or return right (both are same)
    }


    static void Main()
    {
        int[] arr = { 1, 2, 3, 1 };
        int peakIndex = FindPeakElement(arr);
        Console.WriteLine("Peak Element Index: " + peakIndex);
        Console.WriteLine("Peak Element: " + arr[peakIndex]);
    }
}


