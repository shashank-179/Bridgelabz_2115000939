/*4. Handling Multiple Exceptions
💡 Problem Statement:
Create a C# program that performs array operations.
Accept an integer array and an index number.
Retrieve and print the value at that index.
Handle the following exceptions:
IndexOutOfRangeException if the index is out of range.
NullReferenceException if the array is null.
Expected Behavior:
If valid, print "Value at index X: Y".
If the index is out of bounds, display "Invalid index!".
If the array is null, display "Array is not initialized!".
*/

using System;

class Program
{
    static void Main()
    {
        try
        {
            int[] arr = null; // Change to new int[]{1,2,3} for valid case

            Console.Write("Enter index: ");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Value at index {0}: {1}", index, arr[index]);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid index!");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Array is not initialized!");
        }
    }
}



