/*8. Propagating Exceptions Across Methods
💡 Problem Statement:
Create a C# program with three methods:
Method1(): Throws an ArithmeticException (10 / 0).
Method2(): Calls Method1().
Main(): Calls Method2() and handles the exception.
Expected Behavior:
The exception propagates from Method1() → Method2() → Main().
Catch and handle it in Main(), printing "Handled exception in Main".
*/


using System;

class Program
{
    static void Method1()
    {
        throw new ArithmeticException("Division by zero");
    }

    static void Method2()
    {
        Method1();
    }

    static void Main()
    {
        try
        {
            Method2();
        }
        catch (ArithmeticException)
        {
            Console.WriteLine("Handled exception in Main");
        }
    }
}



