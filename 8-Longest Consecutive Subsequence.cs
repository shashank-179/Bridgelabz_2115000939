/*Longest Consecutive Sequence
Problem: Given an unsorted array, find the length of the longest consecutive elements sequence.
Hint: Use a hash map to store elements and check for consecutive elements efficiently.

*/
using System;
using System.Collections.Generic;


class LongestConsecutiveSequence
{
    static int FindLongestConsecutive(int[] nums)
    {
        HashSet<int> set = new HashSet<int>(nums);
        int longest = 0;


        foreach (int num in nums)
        {
            if (!set.Contains(num - 1)) // Start of a sequence
            {
                int currentNum = num;
                int count = 1;


                while (set.Contains(currentNum + 1))
                {
                    currentNum++;
                    count++;
                }


                longest = Math.Max(longest, count);
            }
        }


        return longest;
    }


    static void Main()
    {
        int[] nums = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine(FindLongestConsecutive(nums));
    }
}


