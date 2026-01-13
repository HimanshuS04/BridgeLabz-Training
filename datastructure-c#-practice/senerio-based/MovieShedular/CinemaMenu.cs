using System;
class CinemaMenu
{
    ICinemaService service= new CinemaUtilityImpl();
    public void Start()
    {
        int choice;
        do
        {
            Console.WriteLine(" CinemaTime Menu");
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Search Movie");
            Console.WriteLine("3. Display All Movies");
            Console.WriteLine("4. Print Report");
            Console.WriteLine("0. Exit");

            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Movie Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter Show Time (HH:MM): ");
                    string time = Console.ReadLine();

                    service.AddMovie(title, time);
                    break;
                case 2:
                    Console.Write("Enter keyword: ");
                    service.SearchMovie(Console.ReadLine());
                    break;

                case 3:
                    service.DisplayAllMovies();
                    break;

                case 4:
                    service.PrintReport();
                    break;
                case 0:
                    Console.WriteLine("Exiting ...");
                    break;

            }
        }
        while(choice!=0);
    }
    
}