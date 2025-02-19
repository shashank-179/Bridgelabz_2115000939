using System;
using System.Collections.Generic;

class Program
{
    static bool AreSetsEqual(HashSet<int> set1, HashSet<int> set2)
    {
        return set1.SetEquals(set2);
    }

    static void Main()
    {
        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 2, 1 };

        Console.WriteLine(AreSetsEqual(set1, set2));
    }
}
