using System;
class FinalSalary
{
	public static void Main(string[] args)
	{
		double salary = double.Parse(Console.ReadLine());

		double bonus = double.Parse(Console.ReadLine());

		//Calculating Final Salary
		double finalSalary = salary + bonus;

		Console.WriteLine($"The Salary is INR {salary} and bonus is INR {bonus}. Hence Total income is INR {finalSalary}");

	}
}