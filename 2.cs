/*2. Handling Division and Input Errors
💡 Problem Statement:
Write a C# program that asks the user to enter two numbers and divides them. Handle possible exceptions such as:
DivideByZeroException if division by zero occurs.
FormatException if the user enters a non-numeric value.
Expected Behavior:
If the user enters valid numbers, print the result of the division.
If the user enters 0 as the denominator, catch and handle DivideByZeroException.
If the user enters a non-numeric value, catch and handle FormatException.
*/

using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = num1 / num2;
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input, please enter numbers only!");
        }
    }
}




