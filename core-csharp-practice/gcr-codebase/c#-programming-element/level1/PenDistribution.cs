using System;

class PenDistribution
{
    static void Main()
    {
        int totalPens = 14;
        int students = 3;

        int penStudent = totalPens / students;
        int remainingPens = totalPens % students;

        Console.WriteLine(
            "The Pen Per Student is " + penStudent
 +
            " and the remaining pen not distributed is " + remainingPens
        );
    }
}
