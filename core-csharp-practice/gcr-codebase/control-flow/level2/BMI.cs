using System;
class BMI
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Enter Weight in Kg: ");
		double weight = Convert.ToDouble(Console.ReadLine());

		Console.WriteLine("Enter Height in cm: ");
		double height = Convert.ToDouble(Console.ReadLine());

		double heightInMeter = height / 100;

		double bmi = weight / (heightInMeter * heightInMeter);

		if(bmi <= 18.4){
			Console.WriteLine("UnderWeight");
		}else if(bmi >= 18.5 && bmi <= 24.9){
			Console.WriteLine("Normal");
		}else if(bmi >= 25.0 && bmi <= 39.9){
			Console.WriteLine("OverWeight");
		}else{
			Console.WriteLine("Obese");
		}
	}
}