using System;
class Harshad
{
	public static void Main(string[] args)
	{
		int num = int.Parse(Console.ReadLine());

		int sum = 0;

		int temp = num;

		while(temp > 0){
			int digit = temp % 10;
			sum += digit;
			temp = temp / 10;
		}

		if(num % sum == 0){
			Console.WriteLine("It is a Harshad Number");
		}else{
			Console.WriteLine("It is not a Harshad Number");
		}
	}
}