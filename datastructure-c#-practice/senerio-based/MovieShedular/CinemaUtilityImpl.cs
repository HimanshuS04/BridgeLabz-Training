using System;

class CinemaUtilityImpl : ICinemaService
{
    private GlobalLinkedList MovieList = new GlobalLinkedList();

    public bool AddMovie(string title, string time)
    {
        if (!IsValidTime(time))
        {
            Console.WriteLine("Invalid time format");
            return false;
        }

        Movie movie = new Movie();
        movie.SetTitle(title);
        movie.SetTime(time);

        MovieList.AddLast(movie);
        return true;
    }

    private bool IsValidTime(string time)
    {
        if (time.Length != 5 || time[2] != ':')
            return false;

        if (!int.TryParse(time.Substring(0, 2), out int hour))
            return false;

        if (!int.TryParse(time.Substring(3, 2), out int minute))
            return false;

        return hour >= 0 && hour <= 23 && minute >= 0 && minute <= 59;
    }

    public void SearchMovie(string search)
    {
        GlobalLinkedList.Node current = MovieList.GetHead();
        bool found = false;
        string lowerSearch = search.ToLower();

        while (current != null)
        {
            Movie movie = (Movie)current.GetData();

            if (movie.GetTitle().ToLower().Contains(lowerSearch))
            {
                Console.WriteLine(movie);
                found = true;
            }

            current = current.GetNext();
        }

        if (!found)
            Console.WriteLine("Movie not found!");
    }

    public void DisplayAllMovies()
    {
        GlobalLinkedList.Node current = MovieList.GetHead();

        if (current == null)
        {
            Console.WriteLine("No movies available.");
            return;
        }

        while (current != null)
        {
            Movie movie = (Movie)current.GetData();
            Console.WriteLine(movie);
            current = current.GetNext();
        }
    }

    public void PrintReport()
{
    int count = 0;
    GlobalLinkedList.Node temp = MovieList.GetHead();
    while (temp != null)
    {
        count++;
        temp = temp.GetNext();
    }

    if (count == 0)
    {
        Console.WriteLine("No movies to report.");
        return;
    }
    Movie[] report = new Movie[count];
    temp = MovieList.GetHead();
    for (int i = 0; i < count; i++)
    {
        report[i] = (Movie)temp.GetData(); // cast object to Movie
        temp = temp.GetNext();
    }
    Console.WriteLine("=== Movie Report ===");
    foreach (Movie movie in report)
    {
        Console.WriteLine(movie);
    }
}

}

