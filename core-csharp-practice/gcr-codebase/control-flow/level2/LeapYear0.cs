using System;
class LeapYear0{
	static void Main(string[] args){
		Console.Write("Enter a year: ");
        int year = int.Parse(Console.ReadLine());

        if (year < 1582)
        {
            Console.WriteLine("valid only for year 1582 or later");
        }
        else
        {
            if (year % 400 == 0)
            {
                Console.WriteLine("Year is a Leap Year");
            }
            else if (year % 100 == 0)
            {
                Console.WriteLine("Year is not a Leap Year");
            }
            else if (year % 4 == 0)
            {
                Console.WriteLine("Year is a Leap Year");
            }
            else
            {
                Console.WriteLine("Year is not a Leap Year");
            }	
        }
}
}