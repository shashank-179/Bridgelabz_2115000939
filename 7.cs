/*7. Demonstrating finally Block Execution
💡 Problem Statement:
Write a program that performs integer division and demonstrates the finally block execution.
The program should:
Take two integers from the user.
Perform division.
Handle DivideByZeroException (if dividing by zero).
Ensure "Operation completed" is always printed using finally.
Expected Behavior:
If valid, print the result.
If an exception occurs, handle it and still print "Operation completed".
*/

using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter numerator: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter denominator: ");
            int denom = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Result: " + (num / denom));
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        finally
        {
            Console.WriteLine("Operation completed");
        }
    }
}



