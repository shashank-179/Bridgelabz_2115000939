/*5. Recursive vs Iterative Fibonacci Computation
Objective
Compare Recursive (O(2^N)) vs Iterative (O(N)) Fibonacci solutions.
Approach
Recursive:
public static int FibonacciRecursive(int n) {
    if (n <= 1) return n;
    return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
}
Iterative:
public static int FibonacciIterative(int n) {
    int a = 0, b = 1, sum;
    for (int i = 2; i <= n; i++) {
        sum = a + b;
        a = b;
        b = sum;
    }
    return b;
}
Fibonacci (N)
Recursive (O(2^N))
Iterative (O(N))
10
1ms
0.01ms
30
5s
0.05ms
50
Unfeasible (>1hr)
0.1ms

Expected Result
Recursive approach is infeasible for large values of N due to exponential growth. The iterative approach is significantly faster and memory-efficient.
*/

using System;
using System.Diagnostics;

class FibonacciComparison
{
    // Recursive Fibonacci (O(2^N))
    public static int FibonacciRecursive(int n)
    {
        if (n <= 1) return n;
        return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
    }

    // Iterative Fibonacci (O(N))
    public static int FibonacciIterative(int n)
    {
        int a = 0, b = 1, sum;
        if (n == 0) return a;
        if (n == 1) return b;

        for (int i = 2; i <= n; i++)
        {
            sum = a + b;
            a = b;
            b = sum;
        }
        return b;
    }

    // Method to measure and output execution time for Fibonacci functions
    static void MeasureFibonacciTime(Func<int, int> fibonacciMethod, int n, string methodName)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        fibonacciMethod(n);
        stopwatch.Stop();
        Console.WriteLine($"{methodName} Time for Fibonacci({n}): {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    static void Main()
    {
        int[] testValues = { 10, 30, 50 };

        foreach (int n in testValues)
        {
            Console.WriteLine($"\nTesting Fibonacci for N = {n}:");

            // Measure time for Recursive Fibonacci
            if (n <= 30) // Recursive is feasible for smaller values of N (N <= 30)
            {
                MeasureFibonacciTime(FibonacciRecursive, n, "Recursive Fibonacci");
            }
            else
            {
                Console.WriteLine("Recursive Fibonacci: Unfeasible for large N (>30).");
            }

            // Measure time for Iterative Fibonacci
            MeasureFibonacciTime(FibonacciIterative, n, "Iterative Fibonacci");
        }
    }
}


