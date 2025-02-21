/*9. Using Nested try-catch Blocks
💡 Problem Statement:
Write a C# program that:
Takes an array and a divisor as input.
Tries to access an element at an index.
Tries to divide that element by the divisor.
Uses nested try-catch to handle:
IndexOutOfRangeException if the index is invalid.
DivideByZeroException if the divisor is zero.
Expected Behavior:
If valid, print the division result.
If the index is invalid, catch and display "Invalid array index!".
If division by zero, catch and display "Cannot divide by zero!".
*/
using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter array size: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];

            Console.Write("Enter index: ");
            int index = Convert.ToInt32(Console.ReadLine());

            try
            {
                Console.Write("Enter divisor: ");
                int divisor = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Result: " + (arr[index] / divisor));
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid array index!");
        }
    }
}



