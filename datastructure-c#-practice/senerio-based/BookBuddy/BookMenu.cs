using System;

public class BookMenu
{
    private BookUtilityImpl manager= new BookUtilityImpl();


    public void Start()
    {
        while (true)
        {
            Console.WriteLine("=== BookBuddy Menu ===");
            Console.WriteLine("1. View All Books");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Search Books By Author");
            Console.WriteLine("4. Sort Books Alphabetically");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");
            int choice;

            choice=int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    manager.DisplayAllBooks();
                    break;

                case 2:
                    manager.AddBook();   // utility asks user input
                    break;

                case 3:
                    manager.SearchByAuthor();
                    break;

                case 4:
                    manager.SortBooksAlphabetically();
                    break;

                case 5:
                    Console.WriteLine("Exiting BookBuddy...");
                    return;

                default:
                    Console.WriteLine("Please choose between 1 and 5.");
                    break;
            }
        }
    }
}
