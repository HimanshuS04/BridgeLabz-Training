using System;
class TriangularPark
{
	public static void Main(string[] args)
	{
		
		double side1 = double.Parse(Console.ReadLine());
		double side2 = double.Parse(Console.ReadLine());
		double side3 = double.Parse(Console.ReadLine());

		double perimeter = side1 + side2 + side3;

		// Calculating Rounds And Round them to 1 value after decimal
		double rounds = 5000 / perimeter;
		double finalRound = Math.Round(rounds, 1);

		Console.WriteLine($"The total number of rounds the athlete will run is {finalRound} to complete 5 Km");
	}
}