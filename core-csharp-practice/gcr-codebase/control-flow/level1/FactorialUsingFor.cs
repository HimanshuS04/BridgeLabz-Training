using System;
class FactorialUsingFor
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());
		long fact = 1;

		if (num >= 0){

			for(int i = 1; i <= num; i++){
				fact = fact * i;
			}
			Console.WriteLine($"The Factorial of {num} is {fact}");
		}
	}
}