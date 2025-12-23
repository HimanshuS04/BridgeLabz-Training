using System;
class GreatestFactor
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());
		int greatestFactor = 1;

		for(int i = num - 1; i >= 1; i--){
			if(num % i == 0){
				greatestFactor = i;
				break;
			}
		}
		Console.WriteLine($"Greatest Factor of {num} is {greatestFactor}");
	}
}