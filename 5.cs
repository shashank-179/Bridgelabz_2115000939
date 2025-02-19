using System;
using System.Collections.Generic;

class Program
{
    static string FindNthFromEnd(LinkedList<string> list, int n)
    {
        LinkedListNode<string> mainPointer = list.First;
        LinkedListNode<string> refPointer = list.First;

        for (int i = 0; i < n; i++)
        {
            if (refPointer == null)
                return "N बड़ा है";
            refPointer = refPointer.Next;
        }

        while (refPointer != null)
        {
            mainPointer = mainPointer.Next;
            refPointer = refPointer.Next;
        }

        return mainPointer.Value;
    }

    static void Main()
    {
        LinkedList<string> list = new LinkedList<string>(new string[] { "A", "B", "C", "D", "E" });
        int n = 2;
        Console.WriteLine(FindNthFromEnd(list, n));
    }
}
