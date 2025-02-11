/*Doubly Linked List: Library Management System
Problem Statement: Design a library management system using a doubly linked list. Each node represents a book and contains the following attributes: Book Title, Author, Genre, Book ID, and Availability Status. Implement the following functionalities:
Add a new book at the beginning, end, or at a specific position.
Remove a book by Book ID.
Search for a book by Book Title or Author.
Update a book’s Availability Status.
Display all books in forward and reverse order.
Count the total number of books in the library


*/
using System;

public class BookNode
{
    public string Title;
    public string Author;
    public string Genre;
    public int BookID;
    public bool IsAvailable;
    public BookNode Next;
    public BookNode Prev;

    public BookNode(string title, string author, string genre, int bookID, bool isAvailable)
    {
        Title = title;
        Author = author;
        Genre = genre;
        BookID = bookID;
        IsAvailable = isAvailable;
    }
}

public class LibraryList
{
    private BookNode head;
    private BookNode tail;

    // Add a book at the beginning
    public void AddAtBeginning(string title, string author, string genre, int bookID, bool isAvailable)
    {
        BookNode newBook = new BookNode(title, author, genre, bookID, isAvailable);
        if (head == null)
        {
            head = tail = newBook;
        }
        else
        {
            newBook.Next = head;
            head.Prev = newBook;
            head = newBook;
        }
    }

    // Add a book at the end
    public void AddAtEnd(string title, string author, string genre, int bookID, bool isAvailable)
    {
        BookNode newBook = new BookNode(title, author, genre, bookID, isAvailable);
        if (tail == null)
        {
            head = tail = newBook;
        }
        else
        {
            tail.Next = newBook;
            newBook.Prev = tail;
            tail = newBook;
        }
    }

    // Remove a book by Book ID
    public void RemoveByBookID(int bookID)
    {
        if (head == null) return;

        if (head.BookID == bookID)
        {
            head = head.Next;
            Console.WriteLine("Book with ID " + bookID + " has been deleted.");
            return;
        }

        BookNode current = head;
        while (current.Next != null && current.Next.BookID != bookID)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            Console.WriteLine("Book with ID " + bookID + " not found.");
        }
        else
        {
            current.Next = current.Next.Next;
            Console.WriteLine("Book with ID " + bookID + " has been deleted.");
        }
    }

    // Display all books
    public void DisplayBooks()
    {
        BookNode current = head;
        while (current != null)
        {
            Console.WriteLine("Title: " + current.Title + ", Author: " + current.Author + ", Genre: " + current.Genre + ", ID: " + current.BookID + ", Available: " + (current.IsAvailable ? "Yes" : "No"));
            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LibraryList library = new LibraryList();
        library.AddAtBeginning("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 101, true);
        library.AddAtEnd("To Kill a Mockingbird", "Harper Lee", "Fiction", 102, true);
        library.AddAtEnd("1984", "George Orwell", "Dystopian", 103, false);
        
        Console.WriteLine("Library Books:");
        library.DisplayBooks();

        library.RemoveByBookID(102);

        Console.WriteLine("\nUpdated Library:");
        library.DisplayBooks();
    }
}
