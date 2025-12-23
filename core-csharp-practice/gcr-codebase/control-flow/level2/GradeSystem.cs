using System;
class GradeSystem{
	static void Main(string[] args){
		Console.WriteLine("Enter Marks of physics ");
		int phy=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter Marks of chemsitry ");
		int che=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter Marks of maths ");
		int math=int.Parse(Console.ReadLine());

		
		double per=((phy + che + math)/ 300.0) * 100.0;
		double percent=Math.Round(per,2);


		if(percent>=80){
			Console.WriteLine($"Marks : {percent}% Grade: A Remark: Level4,above agency-normalized standards");
		}
		else if(percent>=70 && percent<80){
			Console.WriteLine($"Marks : {percent}% Grade: B Remark: Level3,at agency-normalized standards");
		}
        else if(percent>=60 && percent<70){
			Console.WriteLine($"Marks : {percent}% Grade: C Remark: Level2,below,but approaching agency-normalized standards");
		}
		else if(percent>=50 && percent<60){
			Console.WriteLine($"Marks : {percent}% Grade: D Remark: Level1,well below agency-normalized standards");
		}
		else if(percent>=40 && percent<50){
			Console.WriteLine($"Marks : {percent}% Grade: E Remark: Level1,too below approaching agency-normalized standards");
		}
		else{
			Console.WriteLine($"Marks : {percent}% Grade: R Remark: Remedial standard");
		}

	}
}