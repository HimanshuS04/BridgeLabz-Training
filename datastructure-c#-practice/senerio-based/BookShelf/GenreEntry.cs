using System;
public class GenreEntry
{
    private string Genre;
    private UniversalLinkedList books;
    public GenreEntry(string genre)
    {
        Genre = genre;
        books = new UniversalLinkedList();
    }
    public string GetGenre()
    {
        return Genre;
    }
    public UniversalLinkedList GetBooks()
    {
        return books;
    }
}