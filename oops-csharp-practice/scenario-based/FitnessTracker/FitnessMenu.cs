class FitnessMenu
{
    FitnessUtilityImpl utility = new FitnessUtilityImpl();

    public void ShowFitnessMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("--- FitTrack FitnessMenu ---");
            Console.WriteLine("1. Enter User Details");
            Console.WriteLine("2. Cardio Training");
            Console.WriteLine("3. Strength Training");
            Console.WriteLine("4. Show User Detail");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateUser();
                    break;

                case 2:
                    Cardio();
                    break;

                case 3:
                    Strength();
                    break;

                case 4:
                    utility.DisplayResult();
                    break;

                case 5:
                    Console.WriteLine("Thank you for using FitTrack!");
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } while (choice != 4);
    }
    void CreateUser()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter Fitness ID: ");
        int id = int.Parse(Console.ReadLine());

        utility.CreateUser(name, age, id);
    }

    void Cardio()
    {
        Console.Write("Enter Cardio Duration (mins): ");
        int duration = int.Parse(Console.ReadLine());

        utility.SetWorkout("Cardio", duration);
        utility.CalculateCalories();
    }

    void Strength()
    {
        Console.Write("Enter Number of Reps: ");
        int reps = int.Parse(Console.ReadLine());

        utility.SetWorkout("Strength", reps);
        utility.CalculateCalories();
    }
}
