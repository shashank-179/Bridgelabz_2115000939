/*Problem Statement: Create a task scheduler using a circular linked list. Each node in the list represents a task with Task ID, Task Name, Priority, and Due Date. Implement the following functionalities:
Add a task at the beginning, end, or at a specific position in the circular list.
Remove a task by Task ID.
View the current task and move to the next task in the circular list.
Display all tasks in the list starting from the head node.
Search for a task by Priority.
*/

using System;

public class TaskNode
{
    public int TaskID;
    public string TaskName;
    public int Priority;
    public DateTime DueDate;
    public TaskNode Next;

    public TaskNode(int taskID, string taskName, int priority, DateTime dueDate)
    {
        TaskID = taskID;
        TaskName = taskName;
        Priority = priority;
        DueDate = dueDate;
        Next = null;
    }
}

public class TaskScheduler
{
    private TaskNode head;

    // Add a task at the end of the circular list
    public void AddTask(int taskID, string taskName, int priority, DateTime dueDate)
    {
        TaskNode newTask = new TaskNode(taskID, taskName, priority, dueDate);
        if (head == null)
        {
            head = newTask;
            newTask.Next = head; // Circular reference
        }
        else
        {
            TaskNode current = head;
            while (current.Next != head)
            {
                current = current.Next;
            }
            current.Next = newTask;
            newTask.Next = head; // Circular reference
        }
    }

    // Display all tasks
    public void DisplayTasks()
    {
        if (head == null) return;

        TaskNode current = head;
        do
        {
            Console.WriteLine("Task ID: " + current.TaskID + ", Task: " + current.TaskName + ", Priority: " + current.Priority + ", Due Date: " + current.DueDate);
            current = current.Next;
        } while (current != head);
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskScheduler taskScheduler = new TaskScheduler();
        taskScheduler.AddTask(1, "Complete Homework", 1, DateTime.Now.AddDays(2));
        taskScheduler.AddTask(2, "Attend Meeting", 2, DateTime.Now.AddDays(1));
        taskScheduler.AddTask(3, "Buy Groceries", 3, DateTime.Now);

        Console.WriteLine("Task Scheduler Records:");
        taskScheduler.DisplayTasks();
    }
}
