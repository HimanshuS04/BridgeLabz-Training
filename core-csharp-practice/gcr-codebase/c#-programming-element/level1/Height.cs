

using System;
class Height{
	static void Main(string[] args){
		int height=int.Parse(Console.ReadLine());
		double tInch=height/2.54;
		int feet= (int)tInch/12;
		double inches= (tInch/12)-feet;
		Console.WriteLine("Your Height in cm is "+height+" while in feet is "+feet+"and inches is"+inches.ToString("0.00"));
	}
}
