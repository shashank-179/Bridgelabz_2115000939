
using System;
using System.Collections.Generic;

class ReverseListt
{
    // Method to reverse a List<T> (ArrayList equivalent)
    static void ReverseList<T>(List<T> list)
    {
        int left = 0, right = list.Count - 1;
        while (left < right)
        {
            T temp = list[left];
            list[left] = list[right];
            list[right] = temp;
            left++;
            right--;
        }
    }

    // Method to reverse a LinkedList<T> in place
    static void ReverseLinkedList<T>(LinkedList<T> linkedList)
    {
        if (linkedList.Count <= 1) return;

        LinkedListNode<T> current = linkedList.First;
        Stack<T> stack = new Stack<T>();

        while (current != null)
        {
            stack.Push(current.Value);
            current = current.Next;
        }

        current = linkedList.First;
        while (current != null)
        {
            current.Value = stack.Pop();
            current = current.Next;
        }
    }

    static void Main()
    {
        // List<T> example
        List<int> arrayList = new List<int> { 1, 2, 3, 4, 5 };
        Console.WriteLine("Original List: " + string.Join(", ", arrayList));
        ReverseList(arrayList);
        Console.WriteLine("Reversed List: " + string.Join(", ", arrayList));

        // LinkedList<T> example
        LinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });
        Console.Write("Original LinkedList: ");
        foreach (var item in linkedList) Console.Write(item + " ");
        Console.WriteLine();

        ReverseLinkedList(linkedList);
        Console.Write("Reversed LinkedList: ");
        foreach (var item in linkedList) Console.Write(item + " ");
        Console.WriteLine();
    }
}

