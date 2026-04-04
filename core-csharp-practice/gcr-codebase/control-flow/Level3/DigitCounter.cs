using System;
class DigitCounter
{
	public static void Main(string[] args)
	{
		int num = int.Parse(Console.ReadLine());

		int count = 0;

		while(num > 0){
			num = num / 10;
			count++;
		}
		Console.WriteLine($"Number of digit is {count}");
	}
}