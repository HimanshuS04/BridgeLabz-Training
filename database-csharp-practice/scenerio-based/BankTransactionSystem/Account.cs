using System;
public class Account
{
    public int AccountId{get; set;}
    public string HolderName{get; set;}
    public decimal Balance{get; set;}
    
    private readonly object _lock = new object();

    public bool Withdraw(decimal amount)
    {
        lock (_lock)
        {
            if (Balance < amount)
                return false;

            Balance -= amount;
            return true;
        }
    }

    public void Deposit(decimal amount)
    {
        lock (_lock)
        {
            Balance += amount;
        }
    }


}