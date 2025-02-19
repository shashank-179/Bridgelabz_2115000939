using System;
using System.Collections.Generic;

class Program
{
    static List<int> RotateList(List<int> list, int k)
    {
        int n = list.Count;
        k = k % n;
        List<int> rotated = new List<int>();

        for (int i = k; i < n; i++)
            rotated.Add(list[i]);
        
        for (int i = 0; i < k; i++)
            rotated.Add(list[i]);

        return rotated;
    }

    static void Main()
    {
        List<int> list = new List<int> { 10, 20, 30, 40, 50 };
        List<int> rotatedList = RotateList(list, 2);

        foreach (var item in rotatedList)
        {
            Console.Write(item + " ");
        }
    }
}
