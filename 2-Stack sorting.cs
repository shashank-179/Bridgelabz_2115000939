/*Sort a Stack Using Recursion
Problem: Given a stack, sort its elements in ascending order using recursion.
Hint: Pop elements recursively, sort the remaining stack, and insert the popped element back at the correct position.
*/
using System;
using System.Collections.Generic;


class SortStack
{
    // Function to insert an element in the correct position
    static void InsertSorted(Stack<int> stack, int element)
    {
        if (stack.Count == 0 || stack.Peek() <= element)
        {
            stack.Push(element);
            return;
        }


        int temp = stack.Pop();
        InsertSorted(stack, element);
        stack.Push(temp);
    }


    // Function to sort the stack using recursion
    static void Sort(Stack<int> stack)
    {
        if (stack.Count == 0)
            return;


        int top = stack.Pop();
        Sort(stack);
        InsertSorted(stack, top);
    }


    static void Main()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(3);
        stack.Push(1);
        stack.Push(4);
        stack.Push(2);


        Sort(stack);


        while (stack.Count > 0)
        {
            Console.WriteLine(stack.Pop());
        }
    }
}


