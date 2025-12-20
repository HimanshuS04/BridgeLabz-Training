using System;
class TemperatureConverter
{
	public static void Main(string[] args)
	{
		double celsiusTemp = double.Parse(Console.ReadLine());

		// Calculations Farh to Celsius
		double FarhTemp = (celsiusTemp * 9 / 5) + 32;

		Console.WriteLine($"The {celsiusTemp} Celsius is {FarhTemp} Farhenheit");
	}
}