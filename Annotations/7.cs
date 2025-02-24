/*2️⃣ Create a Todo Attribute for Pending Tasks
Problem Statement: Define an attribute Todo to mark pending features in a project.
Requirements:
The attribute should have fields: 
Task (string) → Description of the task
AssignedTo (string) → Developer responsible
Priority (default: "MEDIUM")
Apply it to multiple methods.
Retrieve and print all pending tasks using Reflection.
*/
using System;
using System.Reflection;

// Step 1: Define a custom attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class TodoAttribute : Attribute
{
    public string Task { get; }
    public string AssignedTo { get; }
    public string Priority { get; }

    public TodoAttribute(string task, string assignedTo, string priority = "MEDIUM")
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = priority;
    }
}

// Step 2: Apply the attribute to multiple methods
class Project
{
    [Todo("Implement login validation", "Shashank", "HIGH")]
    [Todo("Optimize database queries", "Rohit", "MEDIUM")]
    public void ProcessUserLogin()
    {
        Console.WriteLine("Processing User Login...");
    }

    [Todo("Refactor UI components", "Jay", "LOW")]
    public void RenderDashboard()
    {
        Console.WriteLine("Rendering Dashboard...");
    }

    public void CompletedFeature()
    {
        Console.WriteLine("This feature is already completed.");
    }
}

// Step 3: Retrieve and print all pending tasks using Reflection
class Program
{
    static void Main()
    {
        Type type = typeof(Project);
        MethodInfo[] methods = type.GetMethods();

        Console.WriteLine("Pending Tasks:");
        foreach (MethodInfo method in methods)
        {
            object[] attributes = method.GetCustomAttributes(typeof(TodoAttribute), false);

            foreach (TodoAttribute attr in attributes)
            {
                Console.WriteLine($"- {method.Name}: {attr.Task} (Assigned to: {attr.AssignedTo}, Priority: {attr.Priority})");
            }
        }
        
        // Calling the methods
        Project obj = new Project();
        obj.ProcessUserLogin();
        obj.RenderDashboard();
        obj.CompletedFeature();
    }
}

