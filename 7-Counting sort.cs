/*7. Counting Sort - Sort Student Ages
Problem Statement:
A school collects students’ ages (ranging from 10 to 18) and wants them sorted. Implement Counting Sort in C# for this task.
Hint:
Create a count array to store the frequency of each age.
Compute cumulative frequencies to determine positions.
Place elements in their correct positions in the output array.
*/

using System;

class CountingSort
{
    // Counting Sort function
    static void Sort(int[] arr, int min, int max)
    {
        int range = max - min + 1; // Range of ages (10 to 18 → 9 values)
        int[] count = new int[range]; // Frequency array
        int[] output = new int[arr.Length]; // Sorted output array

        // Step 1: Count occurrences of each element
        for (int i = 0; i < arr.Length; i++)
        {
            count[arr[i] - min]++;
        }

        // Step 2: Compute cumulative count (prefix sum)
        for (int i = 1; i < range; i++)
        {
            count[i] += count[i - 1];
        }

        // Step 3: Place elements in sorted order
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            output[count[arr[i] - min] - 1] = arr[i];
            count[arr[i] - min]--; // Decrease count for next occurrence
        }

        // Copy sorted array back to original array
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = output[i];
        }
    }

    public static void Main()
    {
        Console.WriteLine("Enter number of students:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] ages = new int[n];

        Console.WriteLine($"Enter {n} student ages (between 10 and 18):");
        for (int i = 0; i < n; i++)
        {
            ages[i] = Convert.ToInt32(Console.ReadLine());
        }

        Sort(ages, 10, 18); // Apply Counting Sort

        Console.WriteLine("Sorted student ages:");
        foreach (int age in ages)
        {
            Console.Write(age + " ");
        }
    }
}


