using System;
class AreaOftriangle
{
	public static void Main(string[] args)
	{
		double bInches = Convert.ToDouble(Console.ReadLine());

		double hInches = Convert.ToDouble(Console.ReadLine());

		// Area in square inches
        double areaInches = 0.5 * bInches * hInches;

        // Convert area to square centimeters (1 inch = 2.54 cm)
        double areaCm = areaInches * Math.Pow(2.54, 2);

        Console.WriteLine(
            "The area of triangle is " + areaInches + " square inches and " + areaCm + " square centimeters"
        );

	}
}