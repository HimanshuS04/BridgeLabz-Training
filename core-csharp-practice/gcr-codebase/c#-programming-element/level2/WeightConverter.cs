using System;
class WeightConverter
{
	public static void Main(string[] args)
	{
		
		double pounds = double.Parse(Console.ReadLine());

		//Coverting to Kg

		double inKg = pounds / 2.2;

		Console.WriteLine($"The weight of the person in pounds is {pounds} and in kg is {inKg}");
	}
}
