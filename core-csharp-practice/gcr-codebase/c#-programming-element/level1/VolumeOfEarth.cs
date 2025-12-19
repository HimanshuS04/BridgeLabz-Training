using System;
class VolumeOfEarth
{
	public static void Main(string[] args)
	{
		double radiusInKm = 6378;
		double radiusInMiles = radiusInKm * 1.6;
		double pi = Math.PI;

		double volumeInKm = (4/3) * pi + Math.Pow(radiusInKm, 3);
		double volumeinMiles = (4/3) * pi + Math.Pow(radiusInMiles, 3);

		Console.WriteLine(
            "The volume of earth in cubic kilometers is " + volumeInKm +
            " and cubic miles is " + volumeinMiles
        );
	}
}