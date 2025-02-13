/*Two Sum Problem
Problem: Given an array and a target sum, find two indices such that their values add up to the target.
Hint: Use a hash map to store the index of each element as you iterate. Check if target - current_element exists in the map.

*/
using System;
using System.Collections.Generic;


class TwoSum
{
    static int[] FindTwoSum(int[] nums, int target)
    {
        Dictionary<int, int> map = new Dictionary<int, int>();


        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];


            if (map.ContainsKey(complement))
                return new int[] { map[complement], i };


            map[nums[i]] = i;
        }


        return new int[] { -1, -1 };
    }


    static void Main()
    {
        int[] nums = { 2, 7, 11, 15 };
        int target = 9;


        int[] result = FindTwoSum(nums, target);
        Console.WriteLine(string.Join(", ", result));
    }
}



