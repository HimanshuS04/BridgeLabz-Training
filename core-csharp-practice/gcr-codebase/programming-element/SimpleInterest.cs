using System;
public class SimpleInterest {
	public static void Main(string[] args) {
		double pri = double.Parse(Console.ReadLine());
		double rate = double.Parse(Console.ReadLine());
		double time = double.Parse(Console.ReadLine());
		double si = (pri * rate * time) / 100; //simple interest formula
		Console.WriteLine(si);
	}
}