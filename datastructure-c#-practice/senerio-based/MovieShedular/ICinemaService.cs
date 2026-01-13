interface ICinemaService
{
    bool AddMovie(string title, string time);
    void SearchMovie(string search);
    void DisplayAllMovies();
    void PrintReport();
}
