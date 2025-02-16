/*Binary Search Problem 3: Search for a Target Value in a 2D Sorted Matrix
Problem: You are given a 2D matrix where each row is sorted in ascending order. Write a program that performs Binary Search to find a target value in the matrix.
*/

using System;


class Program
{
    static bool SearchMatrix(int[,] matrix, int target)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int left = 0, right = rows * cols - 1;


        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int midValue = matrix[mid / cols, mid % cols];


            if (midValue == target)
                return true;
            else if (midValue < target)
                left = mid + 1;
            else
                right = mid - 1;
        }


        return false;
    }


    static void Main()
    {
        int[,] matrix = {
            { 1, 3, 5, 7 },
            { 10, 11, 16, 20 },
            { 23, 30, 34, 60 }
        };
        int target = 3;


        Console.WriteLine(SearchMatrix(matrix, target) ? "Found" : "Not Found");
    }
}


