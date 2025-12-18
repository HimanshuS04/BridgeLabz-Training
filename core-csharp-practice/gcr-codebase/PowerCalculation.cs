using System;
public class PowerCalculation {
	static void Main(string[] args) {
		int baseN = int.Parse(Console.ReadLine());
		int exp = int.Parse(Console.ReadLine());;
		double power = Math.Pow(baseN, exp);
		Console.WriteLine(baseN + " raise to the power " + exp + " =" + power);
	}
}