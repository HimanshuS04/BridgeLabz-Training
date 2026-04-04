using System;
class FarhenheitToCelsius
{
	public static void Main(string[] args)
	{
		
		double farhTemp = double.Parse(Console.ReadLine());

		// Conversion of Farh to Celsius
		double celsiusTemp = (farhTemp - 32) * 5 / 9 ;

		Console.WriteLine($"The {farhTemp} Farhenheit is {celsiusTemp} Celsius");
	}
}