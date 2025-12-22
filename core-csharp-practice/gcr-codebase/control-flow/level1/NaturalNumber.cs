using System;
class NaturalNumber{
	static void Main(string[] args){
		int num= Convert.ToInt32(Console.ReadLine());
		if(num>0){
			Console.WriteLine($"The sum of {num} natural numbers is{num*(num+1)/2} ");
		}
		else{
			Console.WriteLine($"The number {num} is not a natural number");
		}
	}
}