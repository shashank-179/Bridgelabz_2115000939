/*Problem Statement: Implement a round-robin CPU scheduling algorithm using a circular linked list. Each node will represent a process and contain Process ID, Burst Time, and Priority. Implement the following functionalities:
Add a new process at the end of the circular list.
Remove a process by Process ID after its execution.
Simulate the scheduling of processes in a round-robin manner with a fixed time quantum.
Display the list of processes in the circular queue after each round.
Calculate and display the average waiting time and turn-around time for all processes.

*/
using System;


public class StudentNode
{
    public int RollNumber;
    public string Name;
    public int Age;
    public double Marks;
    public StudentNode Next;
    public StudentNode Prev;


    public StudentNode(int rollNumber, string name, int age, double marks)
    {
        RollNumber = rollNumber;
        Name = name;
        Age = age;
        Marks = marks;
    }
}


public class ClassList
{
    private StudentNode head;
    private StudentNode tail;


    // Add a student at the beginning
    public void AddAtBeginning(int rollNumber, string name, int age, double marks)
    {
        StudentNode newStudent = new StudentNode(rollNumber, name, age, marks);
        if (head == null)
        {
            head = tail = newStudent;
        }
        else
        {
            newStudent.Next = head;
            head.Prev = newStudent;
            head = newStudent;
        }
    }


    // Add a student at the end
    public void AddAtEnd(int rollNumber, string name, int age, double marks)
    {
        StudentNode newStudent = new StudentNode(rollNumber, name, age, marks);
        if (tail == null)
        {
            head = tail = newStudent;
        }
        else
        {
            tail.Next = newStudent;
            newStudent.Prev = tail;
            tail = newStudent;
        }
    }


    // Remove a student by Roll Number
    public void RemoveStudentByRollNumber(int rollNumber)
    {
        if (head == null) return;


        if (head.RollNumber == rollNumber)
        {
            head = head.Next;
            if (head != null)
                head.Prev = null;
            Console.WriteLine("Student with Roll Number " + rollNumber + " has been removed.");
            return;
        }


        StudentNode current = head;
        while (current != null && current.RollNumber != rollNumber)
        {
            current = current.Next;
        }


        if (current == null)
        {
            Console.WriteLine("Student with Roll Number " + rollNumber + " not found.");
            return;
        }


        if (current.Next != null)
            current.Next.Prev = current.Prev;


        if (current.Prev != null)
            current.Prev.Next = current.Next;


        Console.WriteLine("Student with Roll Number " + rollNumber + " has been removed.");
    }


    // Display all students
    public void DisplayClassList()
    {
        StudentNode current = head;
        while (current != null)
        {
            Console.WriteLine($"Roll Number: {current.RollNumber}, Name: {current.Name}, Age: {current.Age}, Marks: {current.Marks}");
            current = current.Next;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        ClassList classList = new ClassList();
        classList.AddAtBeginning(101, "Ram", 15, 85.5);
        classList.AddAtEnd(102, "Shyam", 14, 90.2);
        classList.AddAtEnd(103, "Suresh", 16, 78.9);


        Console.WriteLine("Class List:");
        classList.DisplayClassList();


        classList.RemoveStudentByRollNumber(102);
        Console.WriteLine("\nUpdated Class List:");
        classList.DisplayClassList();
    }
}


