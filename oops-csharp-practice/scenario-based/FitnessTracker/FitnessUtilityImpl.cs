class FitnessUtilityImpl : ITrackable
{
    private Fitness User;
    private string WorkoutType = "";
    private int value;

    public void CreateUser(string name, int age, int fitnessId)
    {
        User = new Fitness(name, age, fitnessId);
    }

    public void SetWorkout(string WorkoutType, int value)
    {
        this.WorkoutType = WorkoutType;
        this.value = value;
    }

    public void CalculateCalories()
    {
        if (User == null)
        {
            Console.WriteLine("Please enter User details first.");
            return;
        }

        int calories = 0;

        if (WorkoutType == "Cardio")
            calories = value * 8;
        else if (WorkoutType == "Strength")
            calories = value * 5;

        User.SetCalories(calories);
        Console.WriteLine(User.ToString());
    }



    public void DisplayResult()
    {
        Console.WriteLine("\n---- Fitness Report ----");
        Console.WriteLine("Name        : " + User.GetName());
        Console.WriteLine("Age         : " + User.GetAge());
        Console.WriteLine("Fitness ID  : " + User.GetFitnessId());
        Console.WriteLine("Workout     : " + WorkoutType);
        Console.WriteLine("Calories Burned : " + User.GetCalories());
    }
}
