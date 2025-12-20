using System;
class SimpleInterest
{
	public static void Main(string[] args)

	{
		double principal = double.Parse(Console.ReadLine());

		double rate = double.Parse(Console.ReadLine());

		double time = double.Parse(Console.ReadLine());

		// Calculating si

		double si = (principal * rate * time) / 100;

		Console.WriteLine($"The Simple Interest is {si} for Principal {principal}, Rate of Interest {rate} and Time {time}");
	}
}