using System;
class DistributingChocolate
{
	public static void Main(string[] args)
	{
		 
		int nChocolate = Convert.ToInt32(Console.ReadLine());
		int nChildren = Convert.ToInt32(Console.ReadLine());

		// Calculating how many chocolate each children gets and chocolate is remaining 
		int getChocolate = nChoclate / nChildren;
		int remainChocolate = nChoclate % nChildren;

		Console.WriteLine($"The number of chocolates each child gets is {getChocolate} and the number of remaining chocolates is {remainChocolate}");
	}
}