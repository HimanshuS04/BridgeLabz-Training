using System;
class PrimeNumber{
	static void Main(string[] args){
		int num=int.Parse(Console.ReadLine());
		bool isPrime=true;
		if (num==2){
			var=true;

		}
		for(int i=2;i<num;i++){
			if(num%i==0){
				isPrime = false;
				break;
			}
		}
        if(isPrime){
        	Console.WriteLine("its a prime");


        }
        else{
        	Console.WriteLine("not a prime");
        }
		}

	}
