using System;

interface IReservable
{
    void ReserveItem();
    bool CheckAvailability();
}

abstract class LibraryItem
{
    protected int itemId;
    protected string title;

    public LibraryItem(int id, string title)
    {
        itemId = id;
        this.title = title;
    }

    public abstract int GetLoanDuration();

    public void GetItemDetails()
    {
        Console.WriteLine(title + " | Loan Days: " + GetLoanDuration());
    }
}

class Book : LibraryItem
{
    public Book(int id, string title) : base(id, title) { }

    public override int GetLoanDuration()
    {
        return 14;
    }
}
