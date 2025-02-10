/*5. Library Management System
Description: Develop a library management system:
Use an abstract class LibraryItem with fields like itemId, title, and author.
Add an abstract method GetLoanDuration() and a concrete method GetItemDetails().
Create subclasses Book, Magazine, and DVD, overriding GetLoanDuration() with specific logic.
Implement an interface IReservable with methods ReserveItem() and CheckAvailability().
Apply encapsulation to secure details like the borrower’s personal data.
Use polymorphism to allow a general LibraryItem reference to manage all items.
*/
using System;
using System.Collections.Generic;


// Abstract Class
public abstract class LibraryItem
{
    public int ItemId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }


    public abstract int GetLoanDuration();
}


// Subclasses
public class Book : LibraryItem
{
    public override int GetLoanDuration()
    {
        return 14;  // 2 weeks
    }
}


public class Magazine : LibraryItem
{
    public override int GetLoanDuration()
    {
        return 7;  // 1 week
    }
}


// Interface
public interface IReservable
{
    void ReserveItem();
    bool CheckAvailability();
}


// Main Program
public class Program
{
    public static void Main()
    {
        List<LibraryItem> items = new List<LibraryItem>
        {
            new Book { ItemId = 1, Title = "C# Basics", Author = "Abc" },
            new Magazine { ItemId = 2, Title = "C Basics", Author = "Bcd" }
        };


        foreach (var item in items)
        {
            Console.WriteLine("Item: " + item.Title + ", Loan Duration: " + item.GetLoanDuration() + " days");
        }
    }
}


