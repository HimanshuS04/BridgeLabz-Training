using System;
class SumUsingFor
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());
		int total = 0;
		if(num >= 0){
			int sum = num * (num + 1) / 2;

			for(int i = 0; i <= num; i++){
				total += i;
			}

			if(sum == total){
				Console.WriteLine($"Both are equal and the sum is {sum}");
			}else{
				Console.WriteLine($"They are not equal by formual is {sum} and by loop is {total}");
			}
		}
	}
}