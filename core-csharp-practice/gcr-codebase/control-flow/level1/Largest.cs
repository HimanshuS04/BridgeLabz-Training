using System;
class Largest{
	static void Main(string[] args){
		int num1=Convert.ToInt32(Console.ReadLine());
		int num2=Convert.ToInt32(Console.ReadLine());
		int num3=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine($" Is the first number the Largest? {(num1>num2)&&(num1>num3)}");
		Console.WriteLine($" Is the second number the Largest? {(num2>num1)&&(num2>num3)}");
		Console.WriteLine($" Is the third number the Largest? {(num3>num2)&&(num1<num3)}");


	}
}