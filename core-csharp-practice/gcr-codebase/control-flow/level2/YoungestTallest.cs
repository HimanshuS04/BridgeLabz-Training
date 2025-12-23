using System;
class YoungestTallest
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Enter Age of Amar : ");
		int amarAge = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Enter Height of Amar (in cm): ");
		double amarHeight = Convert.ToDouble(Console.ReadLine());

		Console.WriteLine("Enter Age of Akbar : ");
		int akbarAge = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Enter Height of Akbar (in cm): ");
		double akbarHeight = Convert.ToDouble(Console.ReadLine());

		Console.WriteLine("Enter Age of Anthony : ");
		int anthonyAge = Convert.ToInt32(Console.ReadLine());

		Console.WriteLine("Enter Height of Anthony (in cm): ");
		double anthonyHeight = Convert.ToDouble(Console.ReadLine());

		if(amarAge < akbarAge && amarAge < anthonyAge){
			Console.WriteLine("Amar is Youngest");
		}else if(akbarAge < amarAge && akbarAge < anthonyAge){
			Console.WriteLine("Akbar is Youngest");
		}else{
			Console.WriteLine("Anthony is Youngest");
		}

		if(amarHeight > akbarHeight && amarHeight > anthonyHeight){
			Console.WriteLine("Amar is Tallest");
		}else if(akbarHeight > amarHeight && akbarHeight > anthonyHeight){
			Console.WriteLine("Akbar is Tallest");
		}else{
			Console.WriteLine("Anthony is Tallest");
		}

	}
}