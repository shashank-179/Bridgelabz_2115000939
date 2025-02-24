/*Exercise 3: Suppress Warnings for Unchecked Operations
Problem Statement: Create an ArrayList without generics and use #pragma warning disables to hide compilation warnings.
*/

using System.Collections;

class Program
{
    static void Main()
    {
        #pragma warning disable CS0618 // Disable warnings about using obsolete or non-generic collections

        ArrayList list = new ArrayList(); // Using non-generic ArrayList
        list.Add(1);      // Adding an integer
        list.Add("Hello"); // Adding a string
        list.Add(true);   // Adding a boolean
        
        Console.WriteLine("ArrayList Elements:");
        foreach (object item in list)
        {
            Console.WriteLine(item);
        }

        #pragma warning restore CS0618 // Re-enable warnings after this block
    }
}

