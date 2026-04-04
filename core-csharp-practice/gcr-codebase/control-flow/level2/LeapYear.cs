using System;
class LeapYear{
	static void Main(string[] args){
		int year=int.Parse(Console.ReadLine());
		if(year>1582){
			if(((year%4 == 0 )&& (year%100 != 0)) || (year % 400 == 0)){
				Console.WriteLine($"{year} is Leap Year");
			}
			else{
				Console.WriteLine("Not a leap LeapYear");
			}

		}
		else{
			Console.WriteLine("works for year greter then 1582");
		}
	}
}