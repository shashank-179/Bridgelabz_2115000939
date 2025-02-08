/*Sample Problem 1: Library Management with Books and Authors
Description: Model a Book system where Book is the superclass, and Author is a subclass.
Tasks:
Define a superclass Book with attributes like Title and PublicationYear.
Define a subclass Author with additional attributes like Name and Bio.
Create a method DisplayInfo() to show details of the book and its author.
Goal: Practice single inheritance by extending the base class and adding more specific details in the subclass.
*/

using System;

// Superclass: Book
class Book
{
    public string Title;
    public int PublicationYear;

    public Book(string title, int publicationYear)
    {
        Title = title;
        PublicationYear = publicationYear;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}\nPublication Year: {PublicationYear}");
    }
}

// Subclass: Author
class Author : Book
{
    public string Name;
    public string Bio;

    public Author(string title, int publicationYear, string name, string bio)
        : base(title, publicationYear)
    {
        Name = name;
        Bio = bio;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Author: {Name}\nBio: {Bio}");
    }
}

// Main Class
class Program
{
    static void Main()
    {
        Author author = new Author("Harry Potter ", 2007, "JK Rowling", "JK Rowling is a famous writer.");
        author.DisplayInfo();
    }
}

