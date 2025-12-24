using System;
class BMI
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter number of persons: ");
        int n = Convert.ToInt32(Console.ReadLine());
        double[] weights = new double[n];
        double[] heights = new double[n];
        double[] bmi = new double[n];
        string[] weightStatus = new string[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Enter Weight (in kg) of Person " + (i + 1) + ": ");
            weights[i] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Height (in meters) of Person " + (i + 1) + ": ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            bmi[i] = weights[i] / (heights[i] * heights[i]);
            if (bmi[i] < 18.5)
            {
                weightStatus[i] = "Underweight";
            }else if(bmi[i] >= 18.5 && bmi[i] <= 24.9)
            {
                weightStatus[i] = "Normal";
            }else if(bmi[i] > 24.9 && bmi[i] < 29.9)
            {
                weightStatus[i] = "Overweight";
            }
            else
            {
                weightStatus[i] = "Obese";
            }
        }
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("Person " + (i + 1) + ": BMI = " + bmi[i] + ", Weight Status = " + weightStatus[i]);
        }
    }
}