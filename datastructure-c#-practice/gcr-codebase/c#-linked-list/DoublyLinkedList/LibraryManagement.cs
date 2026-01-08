class BookNode
{
    public int id;
    public string title, author;
    public bool available;
    public BookNode prev, next;
}

class Library
{
    BookNode head, tail;

    public void AddBook(int id, string t, string a)
    {
        BookNode node = new BookNode { id = id, title = t, author = a, available = true };
        if (head == null) { head = tail = node; return; }
        tail.next = node;
        node.prev = tail;
        tail = node;
    }

    public int CountBooks()
    {
        int count = 0;
        BookNode temp = head;
        while (temp != null) { count++; temp = temp.next; }
        return count;
    }
}
