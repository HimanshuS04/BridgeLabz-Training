using System;
public class RankMenu
{
    private IRankService service = new RankUtilityImpl();


    public void ShowMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Generate Rank List");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    service.AddStudent();
                    break;

                case 2:
                    service.DisplayAll();
                    break;

                case 3:
                    service.GenerateRankList();
                    break;

                case 4:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        } while (choice != 4);
    }

}
