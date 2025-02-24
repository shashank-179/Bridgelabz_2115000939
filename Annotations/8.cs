/*
3️⃣ Create an Attribute for Logging Method Execution Time
Problem Statement: Define an attribute LogExecutionTime to measure method execution time.
Requirements:
Apply LogExecutionTime to a method.
Use Stopwatch before and after execution.
Print execution time.
Apply it to different methods and compare the time taken.
*/
using System;
using System.Diagnostics;
using System.Reflection;

// Step 1: Define a custom attribute
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
class LogExecutionTimeAttribute : Attribute { }

// Step 2: Create a helper class to execute methods with logging
class MethodTimer
{
    public static void ExecuteWithLogging(object obj, string methodName)
    {
        MethodInfo method = obj.GetType().GetMethod(methodName);
        if (method == null) return;

        if (method.GetCustomAttribute(typeof(LogExecutionTimeAttribute)) != null)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            method.Invoke(obj, null);
            stopwatch.Stop();

            Console.WriteLine($"Execution Time of {method.Name}: {stopwatch.ElapsedMilliseconds} ms");
        }
        else
        {
            method.Invoke(obj, null);
        }
    }
}

// Step 3: Apply the attribute to different methods
class TestClass
{
    [LogExecutionTime]
    public void FastMethod()
    {
        for (int i = 0; i < 1000; i++) { } // Simulating a fast operation
    }

    [LogExecutionTime]
    public void SlowMethod()
    {
        System.Threading.Thread.Sleep(500); // Simulating a slow operation
    }

    public void NormalMethod()
    {
        Console.WriteLine("This method is not logged.");
    }
}

// Step 4: Execute and log method execution time
class Program
{
    static void Main()
    {
        TestClass obj = new TestClass();

        // Execute methods and log their execution time
        MethodTimer.ExecuteWithLogging(obj, "FastMethod");
        MethodTimer.ExecuteWithLogging(obj, "SlowMethod");
        MethodTimer.ExecuteWithLogging(obj, "NormalMethod"); // Not logged
    }
}

