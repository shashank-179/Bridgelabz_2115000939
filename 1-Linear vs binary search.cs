/*1. Search a Target in a Large Dataset
Objective
Compare the performance of Linear Search (O(N)) and Binary Search (O(log N)) on different dataset sizes.
Approach
Linear Search: Scan each element until the target is found.
Binary Search: Sort the data first (O(N log N)), then perform O(log N) search.
Dataset Size (N)
Linear Search (O(N))
Binary Search (O(log N))
1,000
1ms
0.01ms
10,000
10ms
0.02ms
1,000,000
1s
0.1ms

Expected Result
Binary Search performs much better for large datasets, provided data is sorted.
*/

using System;
using System.Diagnostics;

class SearchComparison
{
    static Random random = new Random();

    // Generate random dataset of size N
    static int[] GenerateDataset(int N)
    {
        int[] data = new int[N];
        for (int i = 0; i < N; i++)
        {
            data[i] = random.Next(1, N * 10); // Random values up to 10N
        }
        return data;
    }

    // Linear Search (O(N))
    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
                return i; // Return index if found
        }
        return -1; // Not found
    }

    static void Main()
    {
        int[] sizes = { 1000, 10000, 1000000 }; // Different dataset sizes

        foreach (int N in sizes)
        {
            int[] dataset = GenerateDataset(N);
            int target = dataset[random.Next(0, N)]; // Pick a random target

            // Measure Linear Search Time
            Stopwatch stopwatch = Stopwatch.StartNew();
            LinearSearch(dataset, target);
            stopwatch.Stop();
            double linearTime = stopwatch.Elapsed.TotalMilliseconds;

            // Sort the dataset for Binary Search (O(N log N))
            stopwatch.Restart();
            Array.Sort(dataset);
            stopwatch.Stop();
            double sortTime = stopwatch.Elapsed.TotalMilliseconds;

            // Measure Binary Search Time
            stopwatch.Restart();
            Array.BinarySearch(dataset, target);
            stopwatch.Stop();
            double binaryTime = stopwatch.Elapsed.TotalMilliseconds;

            // Print results
            Console.WriteLine($"Dataset Size: {N}");
            Console.WriteLine($"Linear Search Time: {linearTime:F3} ms");
            Console.WriteLine($"Binary Search Time: {binaryTime:F3} ms");
            Console.WriteLine("------------------------");
        }
    }
}


