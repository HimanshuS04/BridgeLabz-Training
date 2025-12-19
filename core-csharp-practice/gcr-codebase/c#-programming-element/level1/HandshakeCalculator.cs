using System;

class HandshakeCalculator
{
    static void Main(string[] args)
    {
        // Input
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        // Calculate maximum handshakes
        int maxHandshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;

        // Output
        Console.WriteLine(
            "The maximum number of handshakes among " + numberOfStudents +" students is " + maxHandshakes);
    }
}
