using System;
class CounterByFor
{
	public static void Main(string[] args)
	{
		int counter = Convert.ToInt32(Console.ReadLine());

		for(int i = counter; i >= 1; i--){
			Console.WriteLine($"Launch in {counter}");
			counter--;
		}
	}
}