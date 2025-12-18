using System;
public class RectanglePerimeter {
	static void Main(string[] args) {
		double len = double.Parse(Console.ReadLine());
		double width = double.Parse(Console.ReadLine());
		double peri = 2 * (len + width); //perimeter formula
		Console.WriteLine(peri);
	}
}