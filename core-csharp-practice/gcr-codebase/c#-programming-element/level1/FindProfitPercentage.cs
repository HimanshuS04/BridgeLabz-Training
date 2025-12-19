using System;
class FindProfitPercentage
{
	public static void Main(string[] args)
	{
		int sp = 191;
		int cp = 129;

		int profit = sp - cp;
		double profitPercentage = (profit / (double)cp) * 100;

		Console.Write($"The Cost Price is INR {cp} and Selling Price is INR + {sp} \n"+ 
			$"The Profit is INR {profit} and the Profit Percentage is {profitPercentage}"
			);
	}
}