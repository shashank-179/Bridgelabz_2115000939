using System;
using System.Collections.Generic;

class Program
{
    static bool IsSubset(HashSet<int> subset, HashSet<int> mainSet)
    {
        return mainSet.IsSupersetOf(subset);
    }

    static void Main()
    {
        HashSet<int> subset = new HashSet<int> { 2, 3 };
        HashSet<int> mainSet = new HashSet<int> { 1, 2, 3, 4 };

        Console.WriteLine(IsSubset(subset, mainSet));
    }
}
