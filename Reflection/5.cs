using System;
using System.Reflection;

class MathOperations
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
}

class Program
{
    static void Main()
    {
        MathOperations math = new MathOperations();
        Type type = typeof(MathOperations);

        Console.Write("Enter method name (Add, Subtract, Multiply): ");
        string methodName = Console.ReadLine();

        MethodInfo method = type.GetMethod(methodName);
        if (method != null)
        {
            object result = method.Invoke(math, new object[] { 10, 5 });
            Console.WriteLine("Result: " + result);
        }
        else
        {
            Console.WriteLine("Method not found!");
        }
    }
}
