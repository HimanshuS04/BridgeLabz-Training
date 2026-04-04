using System;

class StudentMarks
{
    // Generate random 2-digit scores for Physics, Chemistry, Math
    public static int[,] GenerateScores(int studentCount)
    {
        int[,] scores = new int[studentCount, 3]; // Columns: Physics, Chemistry, Maths
        Random rand = new Random();

        for (int i = 0; i < studentCount; i++)
        {
            scores[i, 0] = rand.Next(0, 101); // Physics 0-100
            scores[i, 1] = rand.Next(0, 101); // Chemistry 0-100
            scores[i, 2] = rand.Next(0, 101); // Maths 0-100
        }

        return scores;
    }

    //  Calculate total, average, percentage
    public static double[,] CalculateTotalAndPercent(int[,] scores)
    {
        int studentCount = scores.GetLength(0);
        double[,] results = new double[studentCount, 3]; // Columns: Total, Average, Percentage

        for (int i = 0; i < studentCount; i++)
        {
            double total = scores[i, 0] + scores[i, 1] + scores[i, 2];
            double average = total / 3.0;
            double percentage = (total / 300.0) * 100;

            results[i, 0] = Math.Round(total, 2);
            results[i, 1] = Math.Round(average, 2);
            results[i, 2] = Math.Round(percentage, 2);
        }

        return results;
    }

    // d. Display scorecard in tabular format
    public static void DisplayScorecard(int[,] scores, double[,] results)
    {
        Console.WriteLine("Student\tPhysics\tChemistry\tMaths\tTotal\tAverage\tPercentage");
        for (int i = 0; i < scores.GetLength(0); i++)
        {
            Console.WriteLine($"{i + 1}\t{scores[i, 0]}\t{scores[i, 1]}\t\t{scores[i, 2]}\t{results[i, 0]}\t{results[i, 1]}\t{results[i, 2]}");
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Enter the number of students: ");
        int studentCount = int.Parse(Console.ReadLine());

        int[,] scores = GenerateScores(studentCount);
        double[,] results = CalculateTotalAndPercent(scores);

        DisplayScorecard(scores, results);
    }
}
