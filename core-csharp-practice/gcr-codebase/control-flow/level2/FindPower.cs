using System;
class FindPower
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());

		int power = Convert.ToInt32(Console.ReadLine());

		int result = 1;

		for (int i = 1; i <= power; i++){
			result *= num;	
		}
		Console.WriteLine(result);

	}
}