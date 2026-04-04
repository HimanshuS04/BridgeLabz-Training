using System;
class FindOddEven
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());

		if(num >= 0){

			for(int i = 1; i <= num; i++){
				if(i % 2 == 0){
					Console.WriteLine($"{i} is a Even Number");
				}else{
					Console.WriteLine($"{i} is a Odd Number");
				}
			}
		}
	}
}