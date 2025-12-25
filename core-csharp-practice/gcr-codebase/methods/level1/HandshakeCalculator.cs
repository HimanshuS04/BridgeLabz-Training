using System;
class HandshakeCalculator
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter number of people: ");
        int n = int.Parse(Console.ReadLine());

        int handshakes = CalculateHandshakes(n);
        Console.WriteLine("Total handshakes: " + handshakes);
    }
    static int CalculateHandshakes(int n)
    {
        return n * (n  - 1) / 2;
    }
}