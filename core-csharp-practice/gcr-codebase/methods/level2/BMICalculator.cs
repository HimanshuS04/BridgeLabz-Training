using System;

class BMICalculator
{
    static void Main(string[] args)
    {

        double[,] data = new double[10, 3];


        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("\nEnter details for Person " + (i + 1));

            Console.Write("Enter weight (kg): ");
            data[i, 0] = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter height (cm): ");
            data[i, 1] = Convert.ToDouble(Console.ReadLine());
        }


        CalculateBMI(data);


        string[] status = GetBMIStatus(data);


        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(
                (i + 1) + "\t" +
                data[i, 0] + "\t" +
                data[i, 1] + "\t" +
                Math.Round(data[i, 2], 2) + "\t\t" +
                status[i]
            );
        }
    }


    static void CalculateBMI(double[,] data)
    {
        for (int i = 0; i < 10; i++)
        {
            double weight = data[i, 0];
            double heightInCm = data[i, 1];


            double heightMeter = heightInCm / 100;


            data[i, 2] = weight / (heightMeter * heightMeter);
        }
    }


    static string[] GetBMIStatus(double[,] data)
    {
        string[] status = new string[10];

        for (int i = 0; i < 10; i++)
        {
            double bmi = data[i, 2];

            if (bmi < 18.5)
                status[i] = "Underweight";
            else if (bmi < 25)
                status[i] = "Normal";
            else if (bmi < 30)
                status[i] = "Overweight";
            else
                status[i] = "Obese";
        }
        return status;
    }
}
