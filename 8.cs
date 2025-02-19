using System;
using System.Collections.Generic;

class Program
{
    static HashSet<int> SymmetricDifference(HashSet<int> set1, HashSet<int> set2)
    {
        HashSet<int> result = new HashSet<int>(set1);
        result.SymmetricExceptWith(set2);
        return result;
    }

    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };

        HashSet<int> result = SymmetricDifference(set1, set2);
        Console.WriteLine(string.Join(", ", result));
    }
}
