/*5. Selection Sort - Sort Exam Scores
Problem Statement:
A university needs to sort students’ exam scores in ascending order. Implement Selection Sort in C# to achieve this.
Hint:
Find the minimum element in the array.
Swap it with the first unsorted element.
Repeat the process for the remaining elements.
*/

using System;

class SelectionSort
{
    // Selection Sort function
    static void Sort(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i; // Assume the first element is the minimum

            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                    minIndex = j; // Update minIndex if a smaller element is found
            }

            // Swap the found minimum element with the first unsorted element
            (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
        }
    }

    public static void Main()
    {
        Console.WriteLine("Enter the number of students:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] scores = new int[n];

        Console.WriteLine($"Enter {n} exam scores:");
        for (int i = 0; i < n; i++)
        {
            scores[i] = Convert.ToInt32(Console.ReadLine());
        }

        Sort(scores); // Apply Selection Sort

        Console.WriteLine("Sorted exam scores:");
        foreach (int score in scores)
        {
            Console.Write(score + " ");
        }
    }
}

