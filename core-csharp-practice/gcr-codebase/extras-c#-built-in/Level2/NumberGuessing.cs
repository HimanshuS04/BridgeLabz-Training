using System;
class NumberGuessing
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Think of a number between 1 and 100.");
        Console.WriteLine("Respond with:");
        Console.WriteLine("'h' if guess is too high");
        Console.WriteLine("'l' if guess is too low");
        Console.WriteLine("'c' if guess is correct");

        int low = 1;
        int high = 100;

        bool isCorrect = false;

        while(!isCorrect)
        {
            int guess = GenerateGuess(low, high);
            Console.WriteLine("Computer guess : " + guess);

            char feedback = GetUserFeedback();
            Console.WriteLine();

            isCorrect = ProcessFeedback(guess, feedback, ref low, ref high);
        }
        Console.WriteLine("Computer guessed it correctly.");
    }

    static int GenerateGuess(int low, int high)
    {
        Random ran = new Random();
        int guess = ran.Next(low, high + 1);
        return guess;
    }

    static char GetUserFeedback()
    {
        Console.WriteLine("Enter your Feedback h/l/c: ");
        return Console.ReadKey().KeyChar;
    }

    static bool ProcessFeedback(int guess, char feedback, ref int low, ref int high)
    {
        if(feedback == 'c')
        {
            return true;
        }else if (feedback == 'h')
        {
            high = guess - 1;
        }else if(feedback == 'l')
        {
            low = guess + 1;
        }
        else
        {
            Console.WriteLine("Invalid Input. Enter h, l or c.");
        }
        return false;
    }
}