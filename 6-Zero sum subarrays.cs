/*Find All Subarrays with Zero Sum
Problem: Given an array, find all subarrays whose elements sum up to zero.
Hint: Use a hash map to store the cumulative sum and its frequency. If a sum repeats, a zero-sum subarray exists.

*/
using System;
using System.Collections.Generic;


class ZeroSumSubarrays
{
    static void FindZeroSumSubarrays(int[] arr)
    {
        Dictionary<int, List<int>> sumMap = new Dictionary<int, List<int>>();
        int sum = 0;


        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];


            if (sum == 0)
                Console.WriteLine("Subarray: 0 to " + i);


            if (sumMap.ContainsKey(sum))
            {
                foreach (var index in sumMap[sum])
                    Console.WriteLine("Subarray: " + (index + 1) + " to " + i);
            }


            if (!sumMap.ContainsKey(sum))
                sumMap[sum] = new List<int>();


            sumMap[sum].Add(i);
        }
    }


    static void Main()
    {
        int[] arr = { 3, 4, -7, 1, 3, 3, -4, -3 };
        FindZeroSumSubarrays(arr);
    }
}
