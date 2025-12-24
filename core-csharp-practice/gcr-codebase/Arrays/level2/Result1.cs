using System;
class Result1
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter number of students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[,] marks = new int[n, 3];
        double[] percentages = new double[n];
        string[] grades = new string[n];

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("For Student " + (i + 1) + ":");
            Console.WriteLine("Enter marks in Physics: ");
            marks[i, 0] = Convert.ToInt32(Console.ReadLine());
            if (marks[i, 0] < 0)
            {
                Console.WriteLine("Invalid marks for Physics. Please enter again.");
                i--;
                continue;
            }
            Console.WriteLine("Enter marks in Chemistry: ");
            marks[i, 1] = Convert.ToInt32(Console.ReadLine());
            if (marks[i, 1] < 0)
            {
                Console.WriteLine("Invalid marks for Chemistry. Please enter again.");
                i--;
                continue;
            }
            Console.WriteLine("Enter marks in Maths: ");
            marks[i, 2] = Convert.ToInt32(Console.ReadLine());
            if (marks[i, 2] < 0)
            {
                Console.WriteLine("Invalid marks for Maths. Please enter again.");
                i--;
                continue;
            }

            int total = marks[i, 0] + marks[i, 1] + marks[i, 2];
            percentages[i] = total / 3.0;

            if(percentages[i] >= 80)
            {
                grades[i] = "A";
            }else if(percentages[i] >= 70 && percentages[i] < 80)
            {
                grades[i] = "B";
            }else if(percentages[i] >= 60 && percentages[i] < 70)
            {
                grades[i] = "C";
            }else if(percentages[i] >= 50 && percentages[i] < 60)
            {
                grades[i] = "D";
            }else if(percentages[i] >= 40 && percentages[i] < 50)
            {
                grades[i] = "E";
            }else
            {
                grades[i] = "F";
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Student " + (i + 1) + ": Percentage = " + percentages[i] + ", Grade = " + grades[i]);
        }
    }
}