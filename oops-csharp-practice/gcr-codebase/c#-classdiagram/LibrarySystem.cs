using System;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }
}

class LibrarySystem
{
    public string Name { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();

    public LibrarySystem(string name)
    {
        Name = name;
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void ShowBooks()
    {
        Console.WriteLine($"LibrarySystem: {Name}");
        foreach (var book in Books)
            Console.WriteLine($"{book.Title} by {book.Author}");
    }
}

class Program
{
    static void Main()
    {
        Book b1 = new Book("Clean Code", "Robert C. Martin");
        Book b2 = new Book("AI Basics", "Andrew Ng");

        LibrarySystem lib1 = new LibrarySystem("Central LibrarySystem");
        LibrarySystem lib2 = new LibrarySystem("College LibrarySystem");

        lib1.AddBook(b1);
        lib2.AddBook(b1);
        lib2.AddBook(b2);

        lib1.ShowBooks();
        lib2.ShowBooks();
    }
}
