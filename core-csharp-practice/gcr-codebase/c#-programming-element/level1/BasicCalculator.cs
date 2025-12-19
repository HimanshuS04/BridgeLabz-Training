using System;
class BasicCalculator
{
	public static void Main(string[] args)
	{
		float num1 = Convert.ToSingle(Console.ReadLine());
		float num2 = Convert.ToSingle(Console.ReadLine());

		float addition = num1 + num2;
        float subtraction = num1 - num2;
        float multiplication = num1 * num2;
        float division = num1 / num2;

        Console.WriteLine(
            "The addition, subtraction, multiplication and division value of 2 numbers " +
            num1
 + " and " + num2 + " is " +
            addition + ", " + subtraction + ", " +
            multiplication + ", and " + division
        );
	}
}