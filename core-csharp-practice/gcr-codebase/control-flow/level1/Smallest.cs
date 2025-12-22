using System;
class Smallest{
	static void Main(string[] args){
		int num1=Convert.ToInt32(Console.ReadLine());
		int num2=Convert.ToInt32(Console.ReadLine());
		int num3=Convert.ToInt32(Console.ReadLine());
		Console.WriteLine($" Is the first number the smallest? {(num1<num2)&&(num1<num3)}");

	}
}