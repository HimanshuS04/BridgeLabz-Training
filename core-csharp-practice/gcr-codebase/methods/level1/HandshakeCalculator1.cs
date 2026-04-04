using System;
class HandshakeCalculator1
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int handshakes = n * (n - 1) / 2;
        Console.WriteLine("Total handshakes: " + handshakes);
    }
}