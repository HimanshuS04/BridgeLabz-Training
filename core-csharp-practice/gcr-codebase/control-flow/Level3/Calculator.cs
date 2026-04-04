using System;
class Calculator
{
	public static void Main(string[] args)
	{
		double fir = Convert.ToDouble(Console.ReadLine());
		double sec = Convert.ToDouble(Console.ReadLine());

		string op = Console.ReadLine();

		if(op == "+" || op == "-" || op == "*" || op == "/"){
			switch (op)
			{
				case "+":
					double sum = fir + sec;
					Console.WriteLine($"{fir} + {sec} = {sum}");
					break;

				case "-":
					double sub = fir - sec;
					Console.WriteLine($"{fir} - {sec} = {sub}");
					break;

				case "*":
					double mult = fir * sec;
					Console.WriteLine($"{fir} * {sec} = {mult}");
					break;

				case "/":
					double div = fir / sec;
					Console.WriteLine($"{fir} / {sec} = {div}");
					break;
			}
		}else{
			Console.WriteLine("Invalid Operator.");
		}
	}
}