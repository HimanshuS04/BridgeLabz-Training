using System;
class FizzBuzz
{
	public static void Main(string[] args)
	{
		int num = Convert.ToInt32(Console.ReadLine());

		if(num > 0){
			for(int i = 0; i <= num; i++){
				if(i % 3 == 0 && i % 5 == 0){
					Console.WriteLine("FizzBuzz");
				}else if(i % 3 == 0){
					Console.WriteLine("Fizz");
				}else if(i % 5 == 0){
					Console.WriteLine("Buzz");
				}else{
					Console.WriteLine(i);
				}
			}
		}
	}
}