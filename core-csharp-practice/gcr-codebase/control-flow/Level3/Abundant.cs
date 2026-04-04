using System;
class Abundant
{
	public static void Main(string[] args)
	{
		int num = int.Parse(Console.ReadLine());

		int sum = 0;

		for(int i = 1; i < num; i++){
			if(num % i == 0){
				sum += i;
			}
		}
		if(sum > num){
			Console.WriteLine("It'sAbundant Number");
		}else{
			Console.WriteLine("It's not a Abundant Number");
		}
	}
}