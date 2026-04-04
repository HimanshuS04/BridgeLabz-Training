
class Visitor
{
    public void PlayLuckyDraw(string name, LuckyDraw luckyDraw)
    {
        Console.Write(name + " Enter your lucky number: ");
        int number = int.Parse(Console.ReadLine());

        if (!luckyDraw.IsValidNumber(number))
        {
            Console.WriteLine("Invalid input! Skipping visitor...");
            return;
        }

        luckyDraw.CheckGift(number);
    }
}
