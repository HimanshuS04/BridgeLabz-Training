using System;
class BMI1
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of persons: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double[,] personData = new double[n, 3];
        string[] weightStatus = new string[n];

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("For Person " + (i + 1) + ":");
            while(true)
            {
                Console.WriteLine("Enter weight (in kg) : ");
                personData[i, 0] = Convert.ToDouble(Console.ReadLine());

                if(personData[i, 0] > 0)
                {
                    break;
                }

                Console.WriteLine("Enter Only Positive Values for weight.");
            }
            while(true)
            {
                Console.WriteLine("Enter height (in meters) : ");
                personData[i, 1] = Convert.ToDouble(Console.ReadLine());

                if(personData[i, 1] > 0)
                {
                    break;
                }

                Console.WriteLine("Enter Only Positive Values for height.");
            }

            personData[i, 2] = personData[i, 0] / (personData[i, 1] * personData[i , 1]);

            if (personData[i, 2] < 18.5)
            {
                weightStatus[i] = "Underweight";
            }else if(personData[i, 2] >= 18.5 && personData[i, 2] < 25.0)
            {
                weightStatus[i] = "Normal";
            }else if(personData[i, 2] >= 25.0 && personData[i , 2] < 30.0)
            {
                weightStatus[i] = "Overweight";
            }
            else
            {
                weightStatus[i] = "Obese";
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Person " + (i + 1) + ": BMI = " + personData[i, 2] + ", Weight Status = " + weightStatus[i]);
        }
    }
}