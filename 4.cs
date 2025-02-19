using System;
using System.Collections.Generic;

class Program
{
    static List<int> RemoveDuplicates(List<int> list)
    {
        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        foreach (var item in list)
        {
            if (!seen.Contains(item))
            {
                seen.Add(item);
                result.Add(item);
            }
        }

        return result;
    }

    static void Main()
    {
        List<int> list = new List<int> { 3, 1, 2, 2, 3, 4 };
        List<int> uniqueList = RemoveDuplicates(list);

        foreach (var item in uniqueList)
        {
            Console.Write(item + " ");
        }
    }
}
