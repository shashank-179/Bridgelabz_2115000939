/*Exercise 5: Create and Use a Repeatable Attribute
Problem Statement: Define an attribute BugReport that can be applied multiple times on a method.
Steps to Follow:
Define BugReport with a Description field.
Use AllowMultiple = true to allow multiple bug reports.
Apply it twice on a method.
Retrieve and print all bug reports.
*/

using System;
using System.Reflection;

// Step 1: Define a custom attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
class BugReportAttribute : Attribute
{
    public string Description { get; }
    
    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

// Step 2: Apply the attribute multiple times
class SoftwareModule
{
    [BugReport("Null reference exception occurs in edge case.")]
    [BugReport("Performance issue when handling large data.")]
    public void ProcessData()
    {
        Console.WriteLine("Processing data...");
    }
}

// Step 3: Retrieve and print all bug reports
class Program
{
    static void Main()
    {
        Type type = typeof(SoftwareModule);
        MethodInfo method = type.GetMethod("ProcessData");

        object[] attributes = method.GetCustomAttributes(typeof(BugReportAttribute), false);

        Console.WriteLine("Bug Reports:");
        foreach (BugReportAttribute attr in attributes)
        {
            Console.WriteLine($"- {attr.Description}");
        }
        
        // Calling the method
        SoftwareModule module = new SoftwareModule();
        module.ProcessData();
    }
}

