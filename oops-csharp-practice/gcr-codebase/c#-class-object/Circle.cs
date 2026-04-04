using System;

class Circle
{
    public double radius;

    public void CalculateArea()
    {
        double area = 3.14 * radius * radius;
        Console.WriteLine("Area of Circle: " + area);
    }

    public void CalculateCircumference()
    {
        double circumference = 2 * 3.14 * radius;
        Console.WriteLine("Circumference of Circle: " + circumference);
    }

    static void Main(string[] args)
    {
        Circle c = new Circle();

        Console.Write("Enter the radius of the circle: ");
        c.radius = double.Parse(Console.ReadLine());

        c.CalculateArea();
        c.CalculateCircumference();
    }
}
