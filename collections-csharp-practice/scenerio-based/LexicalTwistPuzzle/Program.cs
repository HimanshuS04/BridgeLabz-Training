using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the first word");
        string first = Console.ReadLine();

        if (WordValidator.IsInvalid(first))
        {
            Console.WriteLine($"{first} is an invalid word");
            return;
        }

        Console.WriteLine("Enter the second word");
        string second = Console.ReadLine();

        if (WordValidator.IsInvalid(second))
        {
            Console.WriteLine($"{second} is an invalid word");
            return;
        }

        if (StringTransformer.IsReverse(first, second))
        {
            string result = StringTransformer.TransformReversed(first);
            Console.WriteLine(result);
        }
        else
        {
            LexicalAnalyzer.Analyze(first, second);
        }
    }
}
