/*Problem 1: Library and Books (Aggregation)
Description: Create a Library class that contains multiple Book objects. Model the relationship such that a library can have many books, but a book can exist independently (outside of a specific library).
Tasks:
Define a Library class with a List<Book> collection.
Define a Book class with attributes such as Title and Author.
Demonstrate the aggregation relationship by creating books and adding them to different libraries.*/

using System; 
using System.Collections.Generic;  // Importing for using List<>

// Book class representing individual books
class Book
{
    string title;  
    string author; 

    // Constructor
    public Book(string title, string author)
    {
        this.title = title;  
        this.author = author;
    }

    // Method to display book details
    public void Display()
    {
        Console.WriteLine($"Title: {title}, Author: {author}");
    }
}

// Library class representing a collection of books
class Library
{
    public string Name; 
    private List<Book> books; 

    // Constructor to initialize library name and create an empty book list
    public Library(string name)
    {
        Name = name;
        books = new List<Book>(); 
    }

    // Method to add a book to the library
    public void AddBook(Book book)
    {
        books.Add(book);  // Adding a book to the books list
    }

    // Method to display all books in the library
    public void display()
    {
        Console.WriteLine($"Library: {Name}"); 
        if (books.Count == 0)
        {
            Console.WriteLine("No books to display");
        }
        else
        {
            Console.WriteLine("Books in the library:");
            foreach (Book book in books)  
            {
                book.Display();  
            }
        }
        Console.WriteLine("--------------------------");
    }
    public static void Main()
    {
        // Book objects
        Book book1 = new Book("Physics", "Isaac Newton");
        Book book2 = new Book("Chemistry", "Viraf Dalal");
        Book book3 = new Book("Mathematics", "HC Verma");

        // Library objects
        Library lib1 = new Library("School Library");
        Library lib2 = new Library("University Library");

        // Adding books to different libraries
        lib1.AddBook(book1);
        lib2.AddBook(book2);
        lib2.AddBook(book3);

        // Displaying books
        lib1.display();
        lib2.display();
    }
}



