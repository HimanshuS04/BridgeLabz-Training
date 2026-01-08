class MovieNode
{
    public string title, director;
    public int year;
    public double rating;
    public MovieNode prev, next;
}

class MovieList
{
    MovieNode head, tail;

    public void AddAtEnd(string t, string d, int y, double r)
    {
        MovieNode node = new MovieNode { title = t, director = d, year = y, rating = r };
        if (head == null) { head = tail = node; return; }
        tail.next = node;
        node.prev = tail;
        tail = node;
    }

    public void RemoveByTitle(string t)
    {
        MovieNode temp = head;
        while (temp != null)
        {
            if (temp.title == t)
            {
                if (temp.prev != null) temp.prev.next = temp.next;
                else head = temp.next;

                if (temp.next != null) temp.next.prev = temp.prev;
                else tail = temp.prev;
                return;
            }
            temp = temp.next;
        }
    }

    public void DisplayForward()
    {
        MovieNode temp = head;
        while (temp != null)
        {
            Console.WriteLine(temp.title + " " + temp.rating);
            temp = temp.next;
        }
    }

    public void DisplayReverse()
    {
        MovieNode temp = tail;
        while (temp != null)
        {
            Console.WriteLine(temp.title + " " + temp.rating);
            temp = temp.prev;
        }
    }
}
