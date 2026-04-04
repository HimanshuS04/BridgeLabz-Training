using System;
class Counter
{
	public static void Main(string[] args)
	{
		int counter = Convert.ToInt32(Console.ReadLine());

		while(counter >= 1){
			Console.WriteLine($"Launch Begin in {counter}");
			counter--;
		}
	}
}