using System;
class LuckyDraw
{
    public bool IsValidNumber(int number)
    {
        if(number<1)
            return false;
        return true;
    }
    public void CheckGift(int number)
    {
        if (number % 3 == 0 && number % 5 == 0)
            Console.WriteLine("Congratulations! You won a gift!");
        else
            Console.WriteLine(" Better luck next time!");
    }
}