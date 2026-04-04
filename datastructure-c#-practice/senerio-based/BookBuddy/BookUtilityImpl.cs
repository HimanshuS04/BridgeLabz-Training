using System;
public class BookUtilityImpl : IBookManager
{
    private GlobalLinkedList bookList= new GlobalLinkedList();
    public BookUtilityImpl()
    {
        AddPredefinedBook();
    }

    private void AddPredefinedBook()
    {
        Book book1 = new Book();
        book1.SetBook("The Alchemist", "Paulo Coelho");
        bookList.AddLast(book1);

        Book book2 = new Book();
        book2.SetBook("1984", "George Orwell");
        bookList.AddLast(book2);

        Book book3 = new Book();
        book3.SetBook("To Kill a Mockingbird", "Harper Lee");
        bookList.AddLast(book3);
    }

    public void AddBook()
    {
        Console.Write("Enter Book Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author Name: ");
        string author = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            Console.WriteLine("Invalid book details. Book not added.");
            return;
        }

        Book book = new Book();
        book.SetBook(title, author);

        bookList.AddLast(book);

        Console.WriteLine("Book added successfully!");
    }

    public void DisplayAllBooks()
    {
        GlobalLinkedList.Node temp = bookList.GetHead();

        if (temp == null)
        {
            Console.WriteLine("No books available.");
            return;
        }

        while (temp != null)
        {
            Book book = (Book)temp.GetData();
            Console.WriteLine(book);
            temp = temp.GetNext();
        }
    }

    public void SearchByAuthor()
    {
        Console.Write("Enter author name to search: ");
        string keyword = Console.ReadLine();

        bool found = false;
        var current = bookList.GetHead();

        while (current != null)
        {
            Book b = (Book)current.GetData();

            if (b.GetAuthor().ToLower().Contains(keyword.ToLower()))
            {
                Console.WriteLine(b.GetTitle() + " - " + b.GetAuthor());
                found = true;
            }

            current = current.GetNext();
        }

        if (!found)
            Console.WriteLine("No books found for this author.");
    }

    public void SortBooksAlphabetically()
    {
        int count = 0;
        GlobalLinkedList.Node temp = bookList.GetHead();
        while (temp != null)
        {
            count++;
            temp = temp.GetNext();
        }

        if (count == 0)
        {
            Console.WriteLine("No books to sort.");
            return;
        }

        Book[] booksArray = new Book[count];
        temp = bookList.GetHead();
        int index = 0;
        while (temp != null)
        {
            booksArray[index++] = (Book)temp.GetData();
            temp = temp.GetNext();
        }

        for (int i = 0; i < booksArray.Length - 1; i++)
    {
        for (int j = 0; j < booksArray.Length - i - 1; j++)
        {
            if (string.Compare(booksArray[j].GetTitle(), booksArray[j + 1].GetTitle(), StringComparison.OrdinalIgnoreCase) > 0)
            {
                Book tempBook = booksArray[j];
                booksArray[j] = booksArray[j + 1];
                booksArray[j + 1] = tempBook;
            }
        }
    }

        bookList = new GlobalLinkedList();
        foreach (Book book in booksArray)
        {
            bookList.AddLast(book);
        }

        Console.WriteLine("Books sorted alphabetically by title.");
    }
}