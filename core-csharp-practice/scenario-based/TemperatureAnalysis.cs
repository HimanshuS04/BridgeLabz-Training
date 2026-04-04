using System;
class TemperatureAnalysis
{
    static void Main(string[] args)
    {
        float[,] temperature =
        {
            {32.5f,31,32,33,34,35,36,37.5f,38,39,40,41,42,41,40,39,38,37.5f,36,35,34,33,32,31},
            {29,32.5f,31,32,33,34,35,36,37.5f,38,39,40,41,40,39,38,37.5f,36,35,34,33,32,31,32.5f},
            {28,29,32.5f,31,32,33,34,35,36,37.5f,38,39,40,39,38,37.5f,36,35,34,33,32,31,32.5f,29},
            {27,28,29,32.5f,31,32,33,34,35,36,37.5f,38,39,38,37.5f,36,35,34,33,32,31,32.5f,29,28},
            {26,27,28,29,32.5f,31,32,33,34,35,36,37.5f,38,37.5f,36,35,34,33,32,31,32.5f,29,28,27},
            {25,26,27,28,29,32.5f,31,32,33,34,35,36,37.5f,36,35,34,33,32,31,32.5f,29,28,27,26},
            {24,25,26,27,28,29,32.5f,31,32,33,34,35,36,35,34,33,32,31,32.5f,29,28,27,26,25}
        };

        HotAndCold(temperature);
        FindAverage(temperature);
    }

    public static void HotAndCold(float[,] temp)
    {
        float hottest = temp[0, 0];
        float coldest = temp[0, 0];
        int hotDay = 0;
        int coldDay = 0;

        for(int i = 0; i < 7; i++)
        {
            for(int j = 0; j < 24; j++)
            {
                if(temp[i, j] > hottest)
                {
                    hottest = temp[i,j];
                    hotDay = i;
                }
                if(temp[i, j] < coldest)
                {
                    coldest = temp[i, j];
                    coldDay = i;
                }
            }
        }

        Console.WriteLine("Hottest Day: Day " + (hotDay + 1) + " with temperature " + hottest);
        Console.WriteLine("Coldest Day: Day " + (coldDay + 1) + " with temperature " + coldest);
    }

    public static void FindAverage(float[,] temp)
    {
        Console.WriteLine("\nAverage Temperature per Day: ");
        for(int i = 0; i < 7; i++)
        {
            float  sum = 0;
            for(int j = 0; j < 24; j++)
            {
                sum += temp[i, j];
            }
            float avg = sum / 24;
            Console.WriteLine($"Day {i + 1} : {avg}");

        }
    }
}