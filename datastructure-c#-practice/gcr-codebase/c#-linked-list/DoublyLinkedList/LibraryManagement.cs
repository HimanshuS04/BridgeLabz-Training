using System;

class ClassNode
{
    public int id;
    public string title, author;
    public bool available;
    public ClassNode prev, next;
}

class Library
{
    ClassNode head, tail;

    public void AddBook(int id, string t, string a)
    {
        ClassNode node = new ClassNode
        {
            id = id,
            title = t,
            author = a,
            available = true
        };

        if (head == null)
        {
            head = tail = node;
            return;
        }

        tail.next = node;
        node.prev = tail;
        tail = node;
    }

    public int CountBooks()
    {
        int count = 0;
        ClassNode temp = head;
        while (temp != null)
        {
            count++;
            temp = temp.next;
        }
        return count;
    }
}

class Program   // 👈 Main class
{
    static void Main(string[] args)
    {
        Library lib = new Library();

        // Adding books
        lib.AddBook(1, "The Alchemist", "Paulo Coelho");
        lib.AddBook(2, "Wings of Fire", "A. P. J. Abdul Kalam");
        lib.AddBook(3, "Clean Code", "Robert C. Martin");

        // Counting books
        int total = lib.CountBooks();
        Console.WriteLine("Total number of books: " + total);
    }
}
