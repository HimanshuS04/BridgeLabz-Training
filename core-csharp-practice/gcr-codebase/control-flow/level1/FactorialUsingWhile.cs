using System;
class FactorialUsingWhile
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());
		long fact = 1;

		if (num >= 0){
			int i = 1;

			while(i <= num){
				fact = fact * i;
				i++;
			}
			Console.WriteLine($"The Factorial of {num} is {fact}");
		}
	}
}