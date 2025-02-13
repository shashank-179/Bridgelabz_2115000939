/*Implement a Queue Using Stacks
Problem: Design a queue using two stacks such that enqueue and dequeue operations are performed efficiently.
Hint: Use one stack for enqueue and another stack for dequeue. Transfer elements between stacks as needed.
*/
using System;
using System.Collections.Generic;


class QueueUsingStacks
{
    private Stack<int> stack1;
    private Stack<int> stack2;


    public QueueUsingStacks()
    {
        stack1 = new Stack<int>();
        stack2 = new Stack<int>();
    }


    // Enqueue Operation (O(n))
    public void Enqueue(int value)
    {
        // Step 1: Move all elements from stack1 to stack2
        while (stack1.Count > 0)
        {
            stack2.Push(stack1.Pop());
        }


        // Step 2: Push the new element into stack1
        stack1.Push(value);


        // Step 3: Move all elements back to stack1 from stack2
        while (stack2.Count > 0)
        {
            stack1.Push(stack2.Pop());
        }
    }


    // Dequeue Operation (O(1))
    public int Dequeue()
    {
        if (stack1.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }


        return stack1.Pop();  // Oldest element is always at top
    }


    // Check if Queue is Empty
    public bool IsEmpty()
    {
        return stack1.Count == 0;
    }
}


// Driver Code
class Program
{
    static void Main()
    {
        QueueUsingStacks queue = new QueueUsingStacks();
       
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
       
        Console.WriteLine(queue.Dequeue()); // Output: 1
        Console.WriteLine(queue.Dequeue()); // Output: 2
       
        queue.Enqueue(4);
        Console.WriteLine(queue.Dequeue()); // Output: 3
        Console.WriteLine(queue.Dequeue()); // Output: 4


        Console.WriteLine(queue.IsEmpty()); // Output: True
    }
}
