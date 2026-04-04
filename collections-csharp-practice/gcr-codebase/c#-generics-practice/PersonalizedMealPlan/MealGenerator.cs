class MealGenerator<T> where T : IMealPlan
{
    public void Generate(T meal)
    {
        Console.WriteLine($"{meal.MealName} - {meal.Calories} calories");
    }
}
