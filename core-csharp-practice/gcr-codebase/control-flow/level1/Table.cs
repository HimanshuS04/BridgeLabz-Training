using System;
class Table{
	static void Main(string[] args){
		int n=int.Parse(Console.ReadLine());
		if(n>5 && n<10){
		for(int i=1;i<11;i++){
			Console.WriteLine($"{n} * {i} = {n*i}");
		}}
		else{
			Console.WriteLine("enter number btw 6 to 9");
		}
	}
}
