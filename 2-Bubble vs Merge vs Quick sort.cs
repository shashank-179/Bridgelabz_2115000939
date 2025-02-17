/*2. Sorting Large Data Efficiently
Objective
Compare sorting algorithms Bubble Sort (O(N²)), Merge Sort (O(N log N)), and Quick Sort (O(N log N)).
Approach
Bubble Sort: Repeated swapping (inefficient for large data).
Merge Sort: Divide & Conquer approach (stable).
Quick Sort: Partition-based approach (fast but unstable).
Dataset Size (N)
Bubble Sort (O(N²))
Merge Sort (O(N log N))
Quick Sort (O(N log N))
1,000
50ms
5ms
3ms
10,000
5s
50ms
30ms
1,000,000
Unfeasible (>1hr)
3s
2s

Expected Result
Bubble Sort is impractical for large datasets. Merge Sort & Quick Sort perform well.
*/

using System;
using System.Diagnostics;

class SortingComparison
{
    // Bubble Sort (O(N²))
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Merge Sort (O(N log N))
    static void MergeSort(int[] arr)
    {
        MergeSortHelper(arr, 0, arr.Length - 1);
    }

    static void MergeSortHelper(int[] arr, int left, int right)
    {
        if (left >= right) return;
        int mid = (left + right) / 2;
        MergeSortHelper(arr, left, mid);
        MergeSortHelper(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }

    static void Merge(int[] arr, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j]) arr[k++] = L[i++];
            else arr[k++] = R[j++];
        }

        while (i < n1) arr[k++] = L[i++];
        while (j < n2) arr[k++] = R[j++];
    }

    // Quick Sort (O(N log N))
    static void QuickSort(int[] arr)
    {
        QuickSortHelper(arr, 0, arr.Length - 1);
    }

    static void QuickSortHelper(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);
            QuickSortHelper(arr, low, pi - 1);
            QuickSortHelper(arr, pi + 1, high);
        }
    }

    static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;
        return i + 1;
    }

    // Method to measure sorting time
    static void MeasureSortingTime(Action<int[]> sortMethod, int[] dataset, string name)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        sortMethod(dataset);
        stopwatch.Stop();
        Console.WriteLine($"{name} Time: {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    static void Main()
    {
        int[] sizes = { 1000, 10000, 1000000 };

        foreach (int N in sizes)
        {
            Console.WriteLine($"\nDataset Size: {N}");

            // Generate dataset with random integers
            Random random = new Random();
            int[] dataset = new int[N];
            for (int i = 0; i < N; i++)
            {
                dataset[i] = random.Next(0, 1000000);
            }

            // Measure Bubble Sort
            if (N <= 10000) // Bubble Sort is impractical for large N
            {
                MeasureSortingTime(BubbleSort, (int[])dataset.Clone(), "Bubble Sort");
            }
            else
            {
                Console.WriteLine("Bubble Sort: Unfeasible for large datasets.");
            }

            // Measure Merge Sort
            MeasureSortingTime(MergeSort, (int[])dataset.Clone(), "Merge Sort");

            // Measure Quick Sort
            MeasureSortingTime(QuickSort, (int[])dataset.Clone(), "Quick Sort");
        }
    }
}

