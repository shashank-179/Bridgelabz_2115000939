/*Problem Statement: Design an undo/redo functionality for a text editor using a doubly linked list. Each node represents a state of the text content (e.g., after typing a word or performing a command). Implement the following:
Add a new text state at the end of the list every time the user types or performs an action.
Implement the undo functionality (revert to the previous state).
Implement the redo functionality (revert back to the next state after undo).
Display the current state of the text.
Limit the undo/redo history to a fixed size (e.g., last 10 states).

*/
using System;


public class RequestNode
{
    public int RequestID;
    public string CustomerName;
    public string IssueDescription;
    public RequestNode Next;


    public RequestNode(int requestID, string customerName, string issueDescription)
    {
        RequestID = requestID;
        CustomerName = customerName;
        IssueDescription = issueDescription;
        Next = null;
    }
}


public class RequestQueue
{
    private RequestNode front;
    private RequestNode rear;


    // Add a request to the queue
    public void Enqueue(int requestID, string customerName, string issueDescription)
    {
        RequestNode newRequest = new RequestNode(requestID, customerName, issueDescription);
        if (rear == null)
        {
            front = rear = newRequest;
        }
        else
        {
            rear.Next = newRequest;
            rear = newRequest;
        }
    }


    // Remove a request from the queue (FIFO)
    public void Dequeue()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }


        Console.WriteLine($"Processing request ID: {front.RequestID}, Customer: {front.CustomerName}, Issue: {front.IssueDescription}");
        front = front.Next;
        if (front == null) rear = null;  // If the queue is empty
    }


    // Display all requests
    public void DisplayQueue()
    {
        if (front == null)
        {
            Console.WriteLine("Queue is empty.");
            return;
        }


        RequestNode current = front;
        while (current != null)
        {
            Console.WriteLine($"Request ID: {current.RequestID}, Customer: {current.CustomerName}, Issue: {current.IssueDescription}");
            current = current.Next;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        RequestQueue requestQueue = new RequestQueue();
        requestQueue.Enqueue(1, "Harsh", "Account Issue");
        requestQueue.Enqueue(2, "Adi", "Technical Support");
        requestQueue.Enqueue(3, "Anurag", "Billing Query");


        Console.WriteLine("Customer Requests:");
        requestQueue.DisplayQueue();


        requestQueue.Dequeue();
        Console.WriteLine("\nAfter Processing One Request:");
        requestQueue.DisplayQueue();
    }
}
