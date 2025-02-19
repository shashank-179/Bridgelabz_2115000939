using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<int> ConvertToSortedList(HashSet<int> set)
    {
        return set.OrderBy(x => x).ToList();
    }

    static void Main()
    {
        HashSet<int> set = new HashSet<int> { 5, 3, 9, 1 };
        List<int> sortedList = ConvertToSortedList(set);

        Console.WriteLine(string.Join(", ", sortedList));
    }
}
