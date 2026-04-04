using System;

public class VolumeCylinder {
	static void Main(string[] args) {
		double rad = double.Parse(Console.ReadLine());
		double hight = double.Parse(Console.ReadLine());
		double volume = 3.14 * (rad * rad) * hight;
		Console.WriteLine(volume);
	}
}