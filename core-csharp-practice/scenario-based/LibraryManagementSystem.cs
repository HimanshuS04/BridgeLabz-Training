using System;

class LibraryManagementSystem
{
    int bookCount=12;
    string[,] books =
    {
        { "Clean Code", "Robert C. Martin", "Available" },
        { "The Pragmatic Programmer", "Andrew Hunt", "Issued" },
        { "Introduction to Algorithms", "Thomas H. Cormen", "Available" },
        { "Design Patterns", "Erich Gamma", "Issued" },
        { "Effective Java", "Joshua Bloch", "Available" },
        { "Refactoring", "Martin Fowler", "Issued" },
        { "Head First Java", "Kathy Sierra", "Available" },
        { "Code Complete", "Steve McConnell", "Issued" },
        { "Artificial Intelligence", "Stuart Russell", "Available" },
        { "Operating System Concepts", "Abraham Silberschatz", "Issued" },
        { "Computer Networks", "Andrew S. Tanenbaum", "Available" },
        { "Database System Concepts", "Henry F. Korth", "Issued" }
    };

    static void Main(string[] args)
    {
        LibraryManagementSystem library = new LibraryManagementSystem();
        
       library.MainMenu();
    }
 
  void MainMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("\n--- Library Management System ---");
            Console.WriteLine("1. Librarian");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    LibrarianMenu();
                    break;

                case 2:
                    StudentMenu();
                    break;

                case 3:
                    Console.WriteLine("Exiting system...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } while (choice != 3);
    }

    // LIBRARIAN MENU 
    void LibrarianMenu()
    {
        int choice;

        do
        {
            Console.WriteLine(" Librarian Menu ");
            Console.WriteLine("1. Display All Books");
            Console.WriteLine("2. Search Book");
            Console.WriteLine("3. Add Book");
            Console.WriteLine("4. Remove Book");
            Console.WriteLine("5. Back");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayBooks();
                    break;

                case 2:
                    SearchBooks();
                    break;

                case 3:
                    AddBook();
                    break;
                case 4:
                    RemoveBook();
                    break;
                case 5:
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } while (choice != 3);
    }

    //  STUDENT MENU 
    void StudentMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("--- Student Menu ---");
            Console.WriteLine("1. Search Book");
            Console.WriteLine("2. Back");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SearchBooks();
                    break;

                case 2:
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } while (choice != 2);
    }

    void DisplayBooks()
    {
        Console.WriteLine("List of books:");
        for (int i = 0; i < books.GetLength(0); i++)
        {
            Console.WriteLine(
                "Title: " + books[i, 0] + " | " +
                "Author: " + books[i, 1] + " | " +
                "Status: " + books[i, 2]
            );
        }
    }

    void SearchBooks()
    {
        Console.WriteLine("Enter the title of book that you want to search:");
        string title = Console.ReadLine();

        bool found = false;

        for (int i = 0; i < books.GetLength(0); i++)
        {
            if (ContainsIgnoreCase(books[i, 0], title))
            {
                found = true;
                Console.WriteLine("Book has been found: " + books[i, 0]);

                string status = AvailableBook(i);
                Console.WriteLine("Status: " + status);

                if (status == "Available")
                {
                    CheckoutBook(i);
                }
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Book not found");
        }
    }
// check the status of the book 
    string AvailableBook(int i)
    {
        Console.WriteLine("Checking whether the searched book is available or issued");

        bool res = Availabilty(i);

        if (res)
            return "Available";
        else
            return "Issued";
    }

    bool Availabilty(int i)
    {
        if (ContainsIgnoreCase(books[i, 2], "Available"))
            return true;

        return false;
    }
// for checkout the available book 
    void CheckoutBook(int i)
    {
        Console.WriteLine("Do you want to checkout this book? (yes/no)");
        string choice = Console.ReadLine();

        if (choice.ToLower() == "yes")
        {
            books[i, 2] = "Issued";
            Console.WriteLine("Book has been successfully checked out.");
        }
    }
// to compare the two strings
    bool ContainsIgnoreCase(string source, string search)
    {
        return source.ToLower().Contains(search.ToLower());
    }

   // ADD BOOK 
    void AddBook()
    {
        if (bookCount >= books.GetLength(0))
        {
            Console.WriteLine("Library is full");
            return;
        }

        Console.Write("Enter title: ");
        books[bookCount, 0] = Console.ReadLine();

        Console.Write("Enter author: ");
        books[bookCount, 1] = Console.ReadLine();

        books[bookCount, 2] = "Available";

        bookCount++;
        Console.WriteLine("Book added successfully");
    }

    // REMOVE BOOK
    void RemoveBook()
    {
        Console.Write("Enter title to remove: ");
        string title = Console.ReadLine();

        for (int i = 0; i < bookCount; i++)
        {
            if (ContainsIgnoreCase(books[i, 0], title))
            {
                for (int j = i; j < bookCount - 1; j++)
                {
                    books[j, 0] = books[j + 1, 0];
                    books[j, 1] = books[j + 1, 1];
                    books[j, 2] = books[j + 1, 2];
                }

                bookCount--;
                Console.WriteLine("Book removed successfully"+books[i,0]);
                return;
            }
        }

        Console.WriteLine("Book not found");
    }
}

