using System;
class SumOfNum2
{
	public static void Main(string[] args)
	{
		double total = Convert.ToDouble(Console.ReadLine());
		while(true){
			double num = Convert.ToInt32(Console.ReadLine());
			if(num <= 0){
				break;
			}
			total += num;
			Console.WriteLine($"Total sum is {total}");
		}
	}
}