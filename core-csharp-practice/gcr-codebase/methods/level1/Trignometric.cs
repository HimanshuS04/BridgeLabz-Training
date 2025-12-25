using System;
class Trignometic
{
    public static void Main(string[] args)
    {
        Console.Write("Enter angle in degrees: ");
        double angle = double.Parse(Console.ReadLine());

        double[] results = CalculateTrigonometricFunctions(angle);

        Console.WriteLine("Sine Value     : " + results[0]);
        Console.WriteLine("Cosine Value   : " + results[1]);
        Console.WriteLine("Tangent Value  : " + results[2]);
    }

    public static double[] CalculateTrigonometricFunctions(double angle)
    {
        // Convert degrees to radians
        double radians = angle * Math.PI / 180;

        double sin = Math.Sin(radians);
        double cos = Math.Cos(radians);
        double tan = Math.Tan(radians);

        return new double[] { sin, cos, tan };
    }
}