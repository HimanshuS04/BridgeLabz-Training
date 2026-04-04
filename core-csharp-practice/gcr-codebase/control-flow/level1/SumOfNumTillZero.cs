using System;
class SumOfNumTillZero
{
	public static void Main(string[] args)
	{
		double total = 0.0;
		double num = Convert.ToDouble(Console.ReadLine());

		while(num != 0){
			total += num;
			Console.WriteLine($"Total sum is {total}");
			num = Convert.ToDouble(Console.ReadLine());
			
		}
	}
}