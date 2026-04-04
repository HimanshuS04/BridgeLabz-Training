using System;

class CollinearPoint
{
    //  Check collinear using slope formula
    public static bool CollinearBySlope(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        // Avoid division by zero (vertical lines)
        double slopeAB = (x2 - x1) == 0 ? double.PositiveInfinity : (y2 - y1) / (x2 - x1);
        double slopeBC = (x3 - x2) == 0 ? double.PositiveInfinity : (y3 - y2) / (x3 - x2);
        double slopeAC = (x3 - x1) == 0 ? double.PositiveInfinity : (y3 - y1) / (x3 - x1);

        return slopeAB == slopeBC && slopeBC == slopeAC;
    }

    // Check collinear using area of triangle
    public static bool AreCollinearByArea(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        double area = 0.5 * (x1 * (y2 - y3) + 
                             x2 * (y3 - y1) + 
                             x3 * (y1 - y2));
        return area == 0;
    }

    static void Main(string[] args)
    {
        // Sample points: A(2,4), B(4,6), C(6,8)
        Console.WriteLine("Enter coordinates of point A (x1 y1): ");
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter coordinates of point B (x2 y2): ");
        double x2 = double.Parse(Console.ReadLine());
        double y2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter coordinates of point C (x3 y3): ");
        double x3 = double.Parse(Console.ReadLine());
        double y3 = double.Parse(Console.ReadLine());

        bool collinearSlope = CollinearBySlope(x1, y1, x2, y2, x3, y3);
        bool collinearArea = AreCollinearByArea(x1, y1, x2, y2, x3, y3);

        Console.WriteLine("\nCollinear by Slope Method: " + (collinearSlope ? "Yes" : "No"));
        Console.WriteLine("Collinear by Area Method: " + (collinearArea ? "Yes" : "No"));
    }
}
