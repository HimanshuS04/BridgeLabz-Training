using System;

public class BookShelfUtilityImpl : IBookShelf
{
    private UniversalLinkedList[] table;
    private const int SIZE = 10;

    public BookShelfUtilityImpl()
    {
        table = new UniversalLinkedList[SIZE];
        for (int i = 0; i < SIZE; i++)
            table[i] = new UniversalLinkedList();
    }

    private int Hash(string key)
    {
        int sum = 0;
        foreach (char c in key)
            sum += c;
        return sum % SIZE;
    }

    private GenreEntry FindGenre(string genre)
    {
        int index = Hash(genre);
        UniversalLinkedList.Node temp = table[index].GetHead();

        while (temp != null)
        {
            GenreEntry entry = (GenreEntry)temp.GetData();
            if (entry.GetGenre().Equals(genre))
                return entry;

            temp = temp.GetNext();
        }
        return null;
    }

    public void AddBook()
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Author: ");
        string author = Console.ReadLine();

        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        int index = Hash(genre);
        GenreEntry entry = FindGenre(genre);

        if (entry == null)
        {
            entry = new GenreEntry(genre);
            table[index].AddLast(entry);
        }

        Book book = new Book();
        book.SetBook(title, author);
        entry.GetBooks().AddLast(book);

        Console.WriteLine("Book added.");
    }

    public void BorrowBook()
    {
        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        GenreEntry entry = FindGenre(genre);

        if (entry == null || entry.GetBooks().IsEmpty())
        {
            Console.WriteLine("No books available.");
            return;
        }

        Book b = (Book)entry.GetBooks().RemoveFirst();
        Console.WriteLine($"Borrowed: {b.GetTitle()}");
    }

    public void ReturnBook()
    {
        AddBook();
    }

    public void ViewByGenre()
    {
        Console.Write("Genre: ");
        string genre = Console.ReadLine();

        GenreEntry entry = FindGenre(genre);

        if (entry == null)
        {
            Console.WriteLine("Genre not found.");
            return;
        }

        UniversalLinkedList.Node temp = entry.GetBooks().GetHead();

        while (temp != null)
        {
            Book b = (Book)temp.GetData();
            Console.WriteLine(b.ToString());
            temp = temp.GetNext();
        }
    }
}
