
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, double> accounts = new Dictionary<int, double>
        {
            { 101, 5000.0 },
            { 102, 7000.5 },
            { 103, 2500.0 }
        };

        SortedDictionary<int, double> sortedAccounts = new SortedDictionary<int, double>(accounts);
        Queue<int> withdrawalQueue = new Queue<int>();

        withdrawalQueue.Enqueue(101);
        withdrawalQueue.Enqueue(103);
        withdrawalQueue.Enqueue(102);

        Console.WriteLine("Processing Withdrawals:");
        while (withdrawalQueue.Count > 0)
        {
            int accId = withdrawalQueue.Dequeue();
            Console.WriteLine($"Processing withdrawal for Account {accId}");
        }
    }
}

