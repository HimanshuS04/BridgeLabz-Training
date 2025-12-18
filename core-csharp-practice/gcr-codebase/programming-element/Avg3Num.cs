using System;

public class Avg3Num {
	static void Main(string[] args) {
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());
		int c = int.Parse(Console.ReadLine());
		double Average = (a + b + c) / 3;
		Console.WriteLine("Average is "+Average);

	}
}