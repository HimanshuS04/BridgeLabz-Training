using System;
class IntOperation
{
	public static void Main(string[] args)
	{
		// Input
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());
		int c = int.Parse(Console.ReadLine());

		//Perform Operations
		int opt1 = a + b * c;
		int opt2 = a * b + c;
		int opt3 = c + a / b;
		int opt4 = a % b + c;

		Console.WriteLine($"The results of Int Operations are {opt1} , {opt2}, {opt3} and {opt4}");

	}
}