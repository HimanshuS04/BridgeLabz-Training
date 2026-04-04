using System;

class Book
{
    public string title;
    public string author;
    public double price;

    public void DisplayBookDetails()
    {
        Console.WriteLine("Book Title : " + title);
        Console.WriteLine("Author     : " + author);
        Console.WriteLine("Price      : " + price);
    }

    static void Main(string[] args)
    {
        Book b = new Book();

        b.title = "C# Basics";
        b.author = "John Smith";
        b.price = 399;

        b.DisplayBookDetails();
    }
}
