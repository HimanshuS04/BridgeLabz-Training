using System;
public class ATMUtilityImpl : IATMService
{
    private Note Head;

    public void InitializeNotes()
    {
        Head = new Note(500, 10);
        Head.SetNext(new Note(200, 10));
        Head.GetNext()!.SetNext(new Note(100, 10));
        Head.GetNext()!.GetNext()!.SetNext(new Note(50, 10));
        Head.GetNext()!.GetNext()!.GetNext()!.SetNext(new Note(20, 10));
        Head.GetNext()!.GetNext()!.GetNext()!.GetNext()!.SetNext(new Note(10, 10));
        Head.GetNext()!.GetNext()!.GetNext()!.GetNext()!.GetNext()!.SetNext(new Note(5, 10));
        Head.GetNext()!.GetNext()!.GetNext()!.GetNext()!.GetNext()!.GetNext()!.SetNext(new Note(2, 10));
        Head.GetNext()!.GetNext()!.GetNext()!.GetNext()!.GetNext()!.GetNext()!.GetNext()!.SetNext(new Note(1, 10));
    }

    public void DispenseAmount(int amount)
    {
        Note current = Head;
        int remaining = amount;

        Console.WriteLine("\nDispensing ₹" + amount);

        while(current != null && remaining > 0)
        {
            int needed = remaining / current.GetValue();

            if(needed > 0)
            {
                int used = Math.Min(needed, current.GetCount());
                if(used > 0)
                {
                    Console.WriteLine($"{current.GetValue()} x {used}");
                    remaining -= used * current.GetValue();
                }
            }
            current = current.GetNext();
        }
        if(remaining > 0)
        {
            Console.WriteLine("Exact Change is not possible");
        }
    }
    public void RemoveFiveHundred()
    {
        if(Head != null && Head.GetValue() == 500)
        {
            Head = Head.GetNext();
            Console.WriteLine("₹500 notes removed temporarily");
        }
    }
}