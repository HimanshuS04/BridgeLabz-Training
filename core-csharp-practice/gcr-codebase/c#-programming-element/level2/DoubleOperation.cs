using System;
class DoubleOperation
{
	public static void Main(string[] args)
	{
		double a = double.Parse(Console.ReadLine());
		double b = double.Parse(Console.ReadLine());
		double c = double.Parse(Console.ReadLine());

		// Perform Operations
		double opt1 = a + b * c;
		double opt2 = a * b + c;
		double opt3 = c + a / b;
		double opt4 = a % b + c;

		Console.WriteLine($"The results of Double Operations are {opt1} , {opt2}, {opt3} and {opt4}");

	}
}