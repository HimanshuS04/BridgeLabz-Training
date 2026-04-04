using System;
class KilometerToMiles
{
	public static void Main(string[] args)
	{
		double distInKm = 10.5;
		double distInMiles = distInKm * 1.6;

		Console.WriteLine("The distance " + distInKm + "km in miles is " + distInMiles);
	}
}