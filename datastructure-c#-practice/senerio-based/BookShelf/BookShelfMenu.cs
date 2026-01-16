using System;

public class BookShelfMenu
{
    private IBookShelf utility;

    public BookShelfMenu()
    {
        utility = new BookShelfUtilityImpl();
    }

    public void Start()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== BookShelf Menu =====");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Borrow Book");
            Console.WriteLine("3. Return Book");
            Console.WriteLine("4. View Books By Genre");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    utility.AddBook();
                    break;

                case 2:
                    utility.BorrowBook();
                    break;

                case 3:
                    utility.ReturnBook();
                    break;

                case 4:
                    utility.ViewByGenre();
                    break;

                case 5:
                    Console.WriteLine("Exiting BookShelf...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

        } while (choice != 5);
    }
}
