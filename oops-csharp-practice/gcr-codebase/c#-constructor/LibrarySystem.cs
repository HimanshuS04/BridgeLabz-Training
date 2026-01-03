using System;

class LibrarySystem
{
    public string ISBN;
    protected string title;
    private string author;

    public void SetAuthor(string a)
    {
        author = a;
    }

    public string GetAuthor()
    {
        return author;
    }
}

class EBook : LibrarySystem
{
    public void DisplayEBook()
    {
        Console.WriteLine("ISBN : " + ISBN);
        Console.WriteLine("Title: " + title);
    }

    static void Main()
    {
        EBook eb = new EBook();
        eb.ISBN = "ISBN123";
        eb.title = "C# Programming";
        eb.SetAuthor("John");

        eb.DisplayEBook();
        Console.WriteLine("Author:" + eb.GetAuthor());
    }
}
