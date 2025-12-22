using System;
class SpringSeason
{
	public static void Main(string[] args)
	{
		int date = Convert.ToInt32(Console.ReadLine());
		int month = Convert.ToInt32(Console.ReadLine());

		if((month == 3 && date >= 20) || (month == 4) || (month == 5) || (month == 6 && date <= 20)){
			Console.WriteLine("It is a Spring Season");
		}else{
			Console.WriteLine("It is not Spring Season");
		}
	}
}