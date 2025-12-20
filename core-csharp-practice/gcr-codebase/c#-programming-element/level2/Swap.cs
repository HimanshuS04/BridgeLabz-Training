using System;
class Swap
{
	public static void Main(string[] args)
	{
		int temp;
		int num1 = int.Parse(Console.ReadLine());
		int num2 = int.Parse(Console.ReadLine());
		// Swap
		temp = num1;
		num1 = num2;
		num2 = temp;

		Console.WriteLine($"The Swapped numbers are {num1} and {num2}");

	}
}