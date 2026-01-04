using System;

class LibraryMangement
{
    public static string LibraryName = "City Library";
    public readonly string ISBN;
    public string Title;
    public string Author;

    public LibraryMangement(string Title, string Author, string ISBN)
    {
        this.Title = Title;
        this.Author = Author;
        this.ISBN = ISBN;
    }

    public static void DisplayLibraryName()
    {
        Console.WriteLine(LibraryName);
    }

    public void Display(object obj)
    {
        if (obj is LibraryMangement)
        {
            Console.WriteLine(Title + " by " + Author);
        }
    }
}

class Program
{
    static void Main()
    {
        LibraryMangement b1 = new LibraryMangement("C# Basics", "John", "ISBN001");
        b1.Display(b1);
        LibraryMangement.DisplayLibraryName();
    }
}
