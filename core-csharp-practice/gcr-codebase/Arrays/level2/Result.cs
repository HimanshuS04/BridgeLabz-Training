using System;
class Result
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter number of Students: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] physics = new int[n];
        int[] chemistry = new int[n];
        int[] maths = new int[n];

        double[] percentages = new double[n];
        string[] grades = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("For Student " + (i + 1) + ":");
            Console.WriteLine("Enter marks in Physics: ");
            physics[i] = Convert.ToInt32(Console.ReadLine());
            if (physics[i] < 0)
            {
                Console.WriteLine("Invalid marks for Physics. Please enter again.");
                i--;
                continue;
            }
            Console.WriteLine("Enter marks in Chemistry: ");
            chemistry[i] = Convert.ToInt32(Console.ReadLine());
            if (chemistry[i] < 0)
            {
                Console.WriteLine("Invalid marks for Chemistry. Please enter again.");
                i--;
                continue;
            }
            Console.WriteLine("Enter marks in Maths: ");
            maths[i] = Convert.ToInt32(Console.ReadLine());
            if (maths[i] < 0)
            {
                Console.WriteLine("Invalid marks for Maths. Please enter again.");
                i--;
                continue;
            }

            int total = physics[i] + chemistry[i] + maths[i];
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
            }
            else
            {
                grades[i] = "F";
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Student " + (i + 1) + ": Percentage = " + percentages[i] + "%, Grade = " + grades[i]);
        }
    }
}