using System;
public class FitnessMenu
{
    private IStepService service=new StepUtilityImpl();
    public void DisplayMenu()
    {
        int choice;

        do
        {
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. Update Steps");
            Console.WriteLine("3. Show Leaderboard");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter steps: ");
                    int steps = int.Parse(Console.ReadLine());

                    service.AddUser(name, steps);
                    break;

                case 2:
                    Console.Write("Enter user index: ");
                    int index = int.Parse(Console.ReadLine());

                    Console.Write("Enter new steps: ");
                    int newSteps = int.Parse(Console.ReadLine());

                    service.UpdateSteps(index, newSteps);
                    break;

                case 3:
                    service.ShowLeaderboard();
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
