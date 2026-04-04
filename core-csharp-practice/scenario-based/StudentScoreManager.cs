using System;
class StudentScoreManager
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of students");
        int students = int.Parse(Console.ReadLine());

        int[] scores = new int[students];

        ReadScores(scores);

        double average = StudentAverage(scores);
        int highest = HighestScore(scores);
        int lowest = LowestScore(scores);

        Console.WriteLine("Average Score of Students : " + average);
        Console.WriteLine("Highest Score: " + highest);
        Console.WriteLine("Lowest Score: " + lowest);

        DisplayAboveAvg(average, scores);
    }

    static void ReadScores(int[] scores)
    {
        for(int i = 0; i < scores.Length; i++)
        {
            Console.WriteLine("Enter score for student " + (i+1) + ": ");
            int score = int.Parse(Console.ReadLine());

            if(score < 0)
            {
                Console.WriteLine("Invalid Input");
                i--;
            }
            else
            {
                scores[i] = score;
            }

        }
    }

    static double StudentAverage(int[] scores)
    {
        int sum = 0;
        for(int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
        }

        double average = (double)sum / scores.Length;
        return average;
    }

    static int HighestScore(int[] scores)
    {
        int highest = scores[0];

        for(int i = 0; i < scores.Length; i++)
        {
            if(scores[i] > highest)
            {
                highest = scores[i];
            }
        }
        return highest;
    }

    static int LowestScore(int[] scores)
    {
        int lowest = scores[0];
        for(int i = 0; i < scores.Length; i++)
        {
            if(scores[i] < lowest)
            {
                lowest = scores[i];
            }
        }
        return lowest;
    }

    static void DisplayAboveAvg(double average, int[] scores)
    {
        Console.WriteLine("Scores above average : ");
        for(int i = 0; i < scores.Length; i++)
        {
            if(scores[i] > average)
            {
                Console.WriteLine(scores[i]);
            }
        }
    }
}