using System;
using System.Reflection;

class Calculator
{
    private int Multiply(int a, int b)
    {
        return a * b;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();
        Type type = typeof(Calculator);
        MethodInfo method = type.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);

        int result = (int)method.Invoke(calc, new object[] { 5, 6 });
        Console.WriteLine("Multiplication Result: " + result);
    }
}
