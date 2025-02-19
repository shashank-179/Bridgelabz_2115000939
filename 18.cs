using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, double> cart = new Dictionary<string, double>
        {
            { "Apple", 1.2 },
            { "Banana", 0.8 },
            { "Cherry", 2.5 }
        };

        SortedDictionary<string, double> sortedCart = new SortedDictionary<string, double>(cart);

        foreach (var item in sortedCart)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}