using System;

class CafeteriaMenuApp
{
    static void Main(string[] args)
    {
        Cafeteria cafe = new Cafeteria();
        int choice;

        do
        {
            Console.WriteLine("Cafeteria System ");
            Console.WriteLine("1. Owner");
            Console.WriteLine("2. Customer");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    cafe.OwnerMenu();
                    break;

                case 2:
                    int bill = cafe.CustomerMenu();
                    Console.WriteLine("\nTotal Bill: ₹" + bill);
                    Console.WriteLine("Thank you!");
                    break;

                case 3:
                    Console.WriteLine("Exiting system...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 3);
    }
}
