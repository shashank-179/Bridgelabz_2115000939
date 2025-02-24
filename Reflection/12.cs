using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

class SampleClass
{
    public void FastMethod()
    {
        Thread.Sleep(100); // 100ms delay
    }

    public void SlowMethod()
    {
        Thread.Sleep(500); // 500ms delay
    }
}

class Program
{
    static void MeasureExecutionTime(object obj, string methodName)
    {
        Type type = obj.GetType();
        MethodInfo method = type.GetMethod(methodName);

        if (method == null)
        {
            Console.WriteLine($"Method '{methodName}' not found.");
            return;
        }

        Stopwatch stopwatch = Stopwatch.StartNew();
        method.Invoke(obj, null);
        stopwatch.Stop();

        Console.WriteLine($"Execution Time of {methodName}: {stopwatch.ElapsedMilliseconds} ms");
    }

    static void Main()
    {
        SampleClass sample = new SampleClass();

        MeasureExecutionTime(sample, "FastMethod");
        MeasureExecutionTime(sample, "SlowMethod");
    }
}
