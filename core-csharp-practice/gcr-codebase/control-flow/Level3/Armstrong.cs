using System;
class Armstrong
{
	public static void Main(string[] args)
	{
		int num = int.Parse(Console.ReadLine());

		int oNum = num;

		int sum = 0;

		while(oNum > 0){
			int rem = oNum % 10;
			sum += rem * rem * rem;

			oNum = oNum / 10;
		}
		if(num == sum){
			Console.WriteLine("It's Armstrong Number");
		}else{
			Console.WriteLine("It's not an Armstrong Number");
		}
	}
}