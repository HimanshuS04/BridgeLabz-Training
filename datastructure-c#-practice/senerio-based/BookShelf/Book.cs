using System;
public class Book
{
    private string Title;
    private string Author;
    

    public void SetBook(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public string GetTitle()
    {
        return Title;
    }
    public string GetAuthor()
    {
        return Author;
    }
    public override string ToString()
    {
        return $"Title : {Title} , Author : {Author}";
    }
}