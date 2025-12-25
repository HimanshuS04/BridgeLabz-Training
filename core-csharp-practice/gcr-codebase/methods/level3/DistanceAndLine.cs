using System;

class DistanceAndLine
{
    // aMethod to calculate Euclidean dist
    public static double CalculateDistance(double x1, double y1, double x2, double y2)
    {
        double dist = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        return dist;
    }

    //  Method to find slope and y-intercept of the line
    public static double[] FindLineeqn(double x1, double y1, double x2, double y2)
    {
        double[] eqn = new double[2]; // [0] = slope (m), [1] = intercept (b)

        if (x2 == x1) // vertical line
        {
            eqn[0] = double.NaN; // slope undefined
            eqn[1] = double.NaN; // intercept not defined
        }
        else
        {
            double m = (y2 - y1) / (x2 - x1);
            double b = y1 - m * x1;

            eqn[0] = m;
            eqn[1] = b;
        }

        return eqn;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter x1: ");
        double x1 = double.Parse(Console.ReadLine());

        Console.Write("Enter y1: ");
        double y1 = double.Parse(Console.ReadLine());

        Console.Write("Enter x2: ");
        double x2 = double.Parse(Console.ReadLine());

        Console.Write("Enter y2: ");
        double y2 = double.Parse(Console.ReadLine());

        double dist = CalculateDistance(x1, y1, x2, y2);
        Console.WriteLine("\nEuclidean dist between points: " + dist);

        double[] lineEq = FindLineeqn(x1, y1, x2, y2);

        if (double.IsNaN(lineEq[0]))
        {
            Console.WriteLine("The line is vertical. eqn: x = " + x1);
        }
        else
        {
            Console.WriteLine("eqn of the line: y = " + lineEq[0] + "x + " + lineEq[1]);
        }
    }
}
