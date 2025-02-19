using System;
using System.Collections.Generic;

class Patient
{
    public string Name { get; set; }
    public int Severity { get; set; }

    public Patient(string name, int severity)
    {
        Name = name;
        Severity = severity;
    }
}

// Custom Max-Heap based Priority Queue
class MaxHeapPriorityQueue
{
    private List<Patient> heap = new List<Patient>();

    public void Enqueue(Patient patient)
    {
        heap.Add(patient);
        int currentIndex = heap.Count - 1;
        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;
            if (heap[currentIndex].Severity <= heap[parentIndex].Severity)
                break;

            // Swap parent and current node
            (heap[currentIndex], heap[parentIndex]) = (heap[parentIndex], heap[currentIndex]);
            currentIndex = parentIndex;
        }
    }

    public Patient Dequeue()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        Patient root = heap[0];
        heap[0] = heap[^1];
        heap.RemoveAt(heap.Count - 1);

        int currentIndex = 0;
        while (true)
        {
            int leftChild = 2 * currentIndex + 1;
            int rightChild = 2 * currentIndex + 2;
            int largest = currentIndex;

            if (leftChild < heap.Count && heap[leftChild].Severity > heap[largest].Severity)
                largest = leftChild;

            if (rightChild < heap.Count && heap[rightChild].Severity > heap[largest].Severity)
                largest = rightChild;

            if (largest == currentIndex)
                break;

            // Swap current node with largest child
            (heap[currentIndex], heap[largest]) = (heap[largest], heap[currentIndex]);
            currentIndex = largest;
        }

        return root;
    }

    public bool IsEmpty() => heap.Count == 0;
}

class Program
{
    static void Main()
    {
        MaxHeapPriorityQueue queue = new MaxHeapPriorityQueue();

        queue.Enqueue(new Patient("John", 3));
        queue.Enqueue(new Patient("Alice", 5));
        queue.Enqueue(new Patient("Bob", 2));

        Console.WriteLine("Treatment Order:");
        while (!queue.IsEmpty())
        {
            Patient patient = queue.Dequeue();
            Console.WriteLine(patient.Name);
        }
    }
}
