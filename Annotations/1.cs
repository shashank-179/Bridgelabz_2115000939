/*Exercise 1: Use Method Overriding Correctly
Problem Statement: Create a parent class Animal with a method MakeSound(). Then, create a Dog class that overrides this method using override.
Steps to Follow:
Define a MakeSound() method in the Animal class.
Override it in the Dog class with override.
Instantiate Dog and call MakeSound().
*/

using System;

class Animal  // Parent class
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound.");
    }
}

class Dog : Animal  // Child class
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }
}

class Program
{
    static void Main()
    {
        Animal myAnimal = new Animal();
        myAnimal.MakeSound();  // Calls Animal's method

        Dog myDog = new Dog();
        myDog.MakeSound();  // Calls Dog's overridden method
    }
}

