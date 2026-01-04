
using System;
class LibraryBook
{
    public string Title;
    public int PublicationYear;
}
class Author : LibraryBook
{
    public string Name;
    public string Bio;
    public void DisplayInfo()
    {
        Console.WriteLine(Title + " " + PublicationYear);
        Console.WriteLine(Name + " " + Bio);
    }
}
class Program
{
    static void Main()
    {
        Author a = new Author();
        a.Title = "Csharp Basics";
        a.PublicationYear = 2024;
        a.Name = "John Doe";
        a.Bio = "Author";
        a.DisplayInfo();
    }
}
