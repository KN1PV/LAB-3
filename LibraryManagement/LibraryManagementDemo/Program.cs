using System;
using LibraryManagement;

class Program
{
    static void Main(string[] args)
    {
        var library = new Library();

        library.AddBook(new Book("C# in Depth", "Jon Skeet", true));
        library.AddBook(new Book("Clean Code", "Robert C. Martin", true));

        var user = new User("John Doe");
        library.RegisterUser(user);

        Console.WriteLine($"Borrowing book: Clean Code");
        library.BorrowBook("Clean Code", "John Doe");

        Console.WriteLine($"Is 'Clean Code' available? {library.IsBookAvailable("Clean Code")}");

        Console.WriteLine($"Returning book: Clean Code");
        library.ReturnBook("Clean Code", "John Doe");

        Console.WriteLine($"Is 'Clean Code' available? {library.IsBookAvailable("Clean Code")}");

        Console.WriteLine("Library demonstration completed.");
    }
}
