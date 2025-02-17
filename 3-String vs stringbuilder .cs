/*3. String Concatenation Performance
Objective
Compare the performance of string (O(N²)), StringBuilder (O(N)), and StringBuffer (O(N)) when concatenating a million strings.
Approach
Using string (Immutable, creates a new object each time)
Using StringBuilder (Fast, mutable, thread-unsafe)
Operations Count (N)
string (O(N²))
StringBuilder (O(N))
1,000
10ms
1ms
10,000
1s
10ms
1,000,000
30m (Unusable)
50ms

Expected Result
StringBuilder is much more efficient than string for concatenation.
*/

using System;
using System.Diagnostics;

class StringComparison
{
    // Concatenate N strings using String (O(N²)) - immutable
    static void ConcatenateWithString(int N)
    {
        string result = "";
        for (int i = 0; i < N; i++)
        {
            result += "A"; // Concatenating using string (creates a new object each time)
        }
    }

    // Concatenate N strings using StringBuilder (O(N)) - mutable
    static void ConcatenateWithStringBuilder(int N)
    {
        var sb = new System.Text.StringBuilder();
        for (int i = 0; i < N; i++)
        {
            sb.Append("A"); // Concatenating using StringBuilder (mutable)
        }
    }

    // Measure concatenation time for each method
    static void MeasureConcatenationTime(Action<int> concatMethod, int N, string name)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        concatMethod(N); // Execute the method
        stopwatch.Stop();
        Console.WriteLine($"{name} Time for {N} concatenations: {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
    }

    static void Main()
    {
        int[] operations = { 1000, 10000, 1000000 };

        foreach (int N in operations)
        {
            Console.WriteLine($"\nConcatenating {N} strings:");

            // Measure performance using String (only for small N)
            if (N <= 10000)
            {
                MeasureConcatenationTime(ConcatenateWithString, N, "String Concatenation");
            }
            else
            {
                Console.WriteLine("String Concatenation: Unfeasible for large datasets.");
            }

            // Measure performance using StringBuilder
            MeasureConcatenationTime(ConcatenateWithStringBuilder, N, "StringBuilder Concatenation");
        }
    }
}




