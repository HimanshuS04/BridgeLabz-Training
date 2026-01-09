class Fitness
{
    private string Name;
    private int Age;
    private int FitnessId;
    private int CaloriesBurned;

    public Fitness(string Name, int Age, int FitnessId)
    {
        this.Name = Name;
        this.Age = Age;
        this.FitnessId = FitnessId;
    }

    public void SetCalories(int calories)
    {
        CaloriesBurned = calories;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetAge()
    {
        return Age;
    }

    public int GetFitnessId()
    {
        return FitnessId;
    }

    public int GetCalories()
    {
        return CaloriesBurned;
    }
    public override string ToString()
    {
        return "\n---- Fitness Report ----" +
               "\nName           : " + Name +
               "\nAge            : " + Age +
               "\nFitness ID     : " + FitnessId +
               "\nCalories Burned: " + CaloriesBurned;
    }
}
