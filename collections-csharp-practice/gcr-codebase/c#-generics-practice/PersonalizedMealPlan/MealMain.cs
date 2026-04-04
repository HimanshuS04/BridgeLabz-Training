class MealMain
{
    static void Main()
    {
        MealGenerator<VegetarianMeal> gen = new MealGenerator<VegetarianMeal>();
        gen.Generate(new VegetarianMeal());
    }
}
