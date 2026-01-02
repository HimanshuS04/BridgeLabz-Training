using System;
class Program
{
    static void Main()
    {
        Organizer organizer = new Organizer();
        Visitor visitor = new Visitor();
        LuckyDraw luckyDraw = new LuckyDraw();

        int choice;
        int currentVisitor = 0;

        do
        {
            Console.WriteLine("   Diwali Lucky Draw  ");
            Console.WriteLine("1. Organizer");
            Console.WriteLine("2. Visitor");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    organizer.AddVisitors();
                    currentVisitor = 0;
                    break;

                case 2:
                    if (organizer.visitorNames == null)
                    {
                        Console.WriteLine("Organizer must add visitors first!");
                        break;
                    }

                    if (currentVisitor >= organizer.visitorCount)
                    {
                        Console.WriteLine("All visitors have already played!");
                        break;
                    }

                    Console.WriteLine("\nVisitor Turn: " +
                        organizer.visitorNames[currentVisitor]);

                    visitor.PlayLuckyDraw(
                        organizer.visitorNames[currentVisitor],
                        luckyDraw
                    );

                    currentVisitor++;
                    break;

                case 3:
                    Console.WriteLine("Thank you! Happy Diwali ");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 3);
    }
}