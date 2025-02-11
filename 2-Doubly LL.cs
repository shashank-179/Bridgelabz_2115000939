/*Problem Statement: Implement a movie management system using a doubly linked list. Each node will represent a movie and contain Movie Title, Director, Year of Release, and Rating. Implement the following functionalities:
Add a movie record at the beginning, end, or at a specific position.
Remove a movie record by Movie Title.
Search for a movie record by Director or Rating.
Display all movie records in both forward and reverse order.
Update a movie's Rating based on the Movie Title.
*/
using System;

public class MovieNode
{
    public string Title;
    public string Director;
    public int Year;
    public float Rating;
    public MovieNode Next;
    public MovieNode Prev;

    public MovieNode(string title, string director, int year, float rating)
    {
        Title = title;
        Director = director;
        Year = year;
        Rating = rating;
    }
}

public class MovieList
{
    private MovieNode head;
    private MovieNode tail;

    // Add a movie at the beginning
    public void AddAtBeginning(string title, string director, int year, float rating)
    {
        MovieNode newMovie = new MovieNode(title, director, year, rating);
        if (head == null)
        {
            head = tail = newMovie;
        }
        else
        {
            newMovie.Next = head;
            head.Prev = newMovie;
            head = newMovie;
        }
    }

    // Add a movie at the end
    public void AddAtEnd(string title, string director, int year, float rating)
    {
        MovieNode newMovie = new MovieNode(title, director, year, rating);
        if (tail == null)
        {
            head = tail = newMovie;
        }
        else
        {
            tail.Next = newMovie;
            newMovie.Prev = tail;
            tail = newMovie;
        }
    }

    // Delete a movie by Title
    public void DeleteByTitle(string title)
    {
        MovieNode current = head;
        while (current != null)
        {
            if (current.Title == title)
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    tail = current.Prev;

                Console.WriteLine("Movie '" + title + "' has been deleted.");
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("Movie '" + title + "' not found.");
    }

    // Search a movie by Director
    public void SearchByDirector(string director)
    {
        MovieNode current = head;
        while (current != null)
        {
            if (current.Director == director)
            {
                Console.WriteLine("Movie found: " + current.Title);
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("No movie directed by " + director + " found.");
    }

    // Update a movie's rating
    public void UpdateRating(string title, float newRating)
    {
        MovieNode current = head;
        while (current != null)
        {
            if (current.Title == title)
            {
                current.Rating = newRating;
                Console.WriteLine("Rating of movie '" + title + "' updated to " + newRating);
                return;
            }
            current = current.Next;
        }
        Console.WriteLine("Movie '" + title + "' not found.");
    }

    // Display all movies
    public void DisplayList()
    {
        MovieNode current = head;
        while (current != null)
        {
            Console.WriteLine("Title: " + current.Title + ", Director: " + current.Director + ", Year: " + current.Year + ", Rating: " + current.Rating);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        MovieList movieList = new MovieList();
        movieList.AddAtBeginning("Inception", "Christopher Nolan", 2010, 8.8f);
        movieList.AddAtEnd("Interstellar", "Christopher Nolan", 2014, 8.6f);
        movieList.AddAtEnd("The Dark Knight", "Christopher Nolan", 2008, 9.0f);
        movieList.AddAtBeginning("Memento", "Christopher Nolan", 2000, 8.4f);

        Console.WriteLine("Movie Records:");
        movieList.DisplayList();

        movieList.SearchByDirector("Christopher Nolan");

        movieList.UpdateRating("Interstellar", 9.0f);

        movieList.DeleteByTitle("Inception");

        Console.WriteLine("\nUpdated Movie Records:");
        movieList.DisplayList();
    }
}
