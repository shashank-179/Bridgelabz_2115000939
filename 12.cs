using System;
using System.Collections.Generic;

class Program
{
    static List<string> GenerateBinaryNumbers(int n)
    {
        Queue<string> queue = new Queue<string>();
        List<string> result = new List<string>();

        queue.Enqueue("1");

        for (int i = 0; i < n; i++)
        {
            string front = queue.Dequeue();
            result.Add(front);
            queue.Enqueue(front + "0");
            queue.Enqueue(front + "1");
        }

        return result;
    }

    static void Main()
    {
        int n = 5;
        List<string> binaryNumbers = GenerateBinaryNumbers(n);

        Console.WriteLine(string.Join(", ", binaryNumbers));
    }
}
