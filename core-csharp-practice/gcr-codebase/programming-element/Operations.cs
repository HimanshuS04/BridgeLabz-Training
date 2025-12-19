using System;
class Operations
{
	public static void Main(string[] args)
	{
		// Arithimatic Operators
		int n1 = 56;
		int n2 = 45;

		Console.WriteLine("Addition: " + (n1 + n2)); 
		Console.WriteLine("Subtraction: " + (n1 - n2)); 
		Console.WriteLine("Multiplication: " + (n1 * n2)); 
		Console.WriteLine("Division: " + (n1 / n2)); 
		Console.WriteLine("Modulus: " + (n1 % n2)); 

		

		// Relational Operators
		int nn1 = 10;
		int nn2= 5;

		Console.WriteLine("nn1 == nn2: " + (nn1 == nn2)); 
		Console.WriteLine("nn1 != nn2: " + (nn1 != nn2)); 
		Console.WriteLine("nn1 > nn2: " + (nn1 > nn2)); 
		Console.WriteLine("nn1 < nn2: " + (nn1 < nn2)); 
		Console.WriteLine("nn1 >= nn2: " + (nn1 >= nn2)); 
		Console.WriteLine("nn1 <= nn2: " + (nn1 <= nn2)); 

		

		// Logical Operators

		bool x = true;
		bool y = false;

		Console.WriteLine("x && y: " + (x && y)); 
		Console.WriteLine("x || y: " + (x || y)); 
		Console.WriteLine("!x: " + (!x)); 
		Console.WriteLine("!y: " + (!y));

		

		// Assignment Operator

		int a = 56;
		int b = 34;

		a += b; 
		Console.WriteLine("a += b: " + a); 

		a -= b; 
		Console.WriteLine("a -= b: " + a); 

		a *= b; 
		Console.WriteLine("a *= b: " + a); 

		a /= b; 
		Console.WriteLine("a /= b: " + a); 

		a %= b; 
		Console.WriteLine("a %= b: " + a); 

	
		// Unary Operators

		int c = 5;

		Console.WriteLine("c: " + a); 
		Console.WriteLine("++c: " + ++a); 
		Console.WriteLine("c++: " + a++); 
		Console.WriteLine("c: " + a); 
		Console.WriteLine("--c: " + --a); 
		Console.WriteLine("c--: " + a--); 
		Console.WriteLine("c: " + a); 
	}
}