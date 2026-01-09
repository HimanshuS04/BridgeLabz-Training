using System;

class ClassNode
{
    public string title, director;
    public int year;
    public double rating;
    public ClassNode prev, next;
}

class MovieList
{
    ClassNode head, tail;

    public void AddAtEnd(string t, string d, int y, double r)
    {
        ClassNode node = new ClassNode
        {
            title = t,
            director = d,
            year = y,
            rating = r
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

    public void RemoveByTitle(string t)
    {
        ClassNode temp = head;

        while (temp != null)
        {
            if (temp.title == t)
            {
                if (temp.prev != null)
                    temp.prev.next = temp.next;
                else
                    head = temp.next;

                if (temp.next != null)
                    temp.next.prev = temp.prev;
                else
                    tail = temp.prev;

                Console.WriteLine("Movie removed: " + t);
                return;
            }
            temp = temp.next;
        }

        Console.WriteLine("Movie not found: " + t);
    }

    public void DisplayForward()
    {
        Console.WriteLine("Movies (Forward):");
        ClassNode temp = head;

        while (temp != null)
        {
            Console.WriteLine(
                "Title: " + temp.title +
                ", Rating: " + temp.rating
            );
            temp = temp.next;
        }
    }

    public void DisplayReverse()
    {
        Console.WriteLine("Movies (Reverse):");
        ClassNode temp = tail;

        while (temp != null)
        {
            Console.WriteLine(
                "Title: " + temp.title +
                ", Rating: " + temp.rating
            );
            temp = temp.prev;
        }
    }
}

class Program   
{
    static void Main(string[] args)
    {
        MovieList movies = new MovieList();

        movies.AddAtEnd("Inception", "Christopher Nolan", 2010, 8.8);
        movies.AddAtEnd("Interstellar", "Christopher Nolan", 2014, 8.6);
        movies.AddAtEnd("The Matrix", "Wachowski Sisters", 1999, 8.7);

        movies.DisplayForward();

        Console.WriteLine();
        movies.RemoveByTitle("Interstellar");

        Console.WriteLine();
        movies.DisplayReverse();
    }
}
