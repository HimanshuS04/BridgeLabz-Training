using System;
class Multiple
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());

		for(int i = 100; i >= 1; i--){
			if(num % i == 0){
				Console.WriteLine(i);
				continue;
			}
		}
	}
}