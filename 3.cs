/*3. Creating and Handling a Custom Exception
💡 Problem Statement:
Create a custom exception called InvalidAgeException.
Write a method ValidateAge(int age) that throws InvalidAgeException if the age is below 18.
In Main(), take user input and call ValidateAge().
If an exception occurs, display "Age must be 18 or above".
Expected Behavior:
If the age is >=18, print "Access granted!".
If age <18, throw InvalidAgeException and display the message.
*/

using System;

class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message) { }
}

class Program
{
    static void ValidateAge(int age)
    {
        if (age < 18)
            throw new InvalidAgeException("Age must be 18 or above");
    }

    static void Main()
    {
        try
        {
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            ValidateAge(age);
            Console.WriteLine("Access granted!");
        }
        catch (InvalidAgeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}



