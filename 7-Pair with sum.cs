/*Check for a Pair with Given Sum in an Array
Problem: Given an array and a target sum, find if there exists a pair of elements whose sum is equal to the target.
Hint: Store visited numbers in a hash map and check if target - current_number exists in the map.

*/
using System;
using System.Collections.Generic;


class PairWithSum
{
    static bool HasPairWithSum(int[] nums, int target)
    {
        HashSet<int> seen = new HashSet<int>();


        foreach (int num in nums)
        {
            if (seen.Contains(target - num))
                return true;


            seen.Add(num);
        }


        return false;
    }


    static void Main()
    {
        int[] nums = { 1, 4, 6, 8, 10 };
        int target = 14;


        Console.WriteLine(HasPairWithSum(nums, target));
    }
}



