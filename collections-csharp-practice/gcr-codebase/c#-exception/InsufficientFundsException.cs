using System;

class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string msg) : base(msg) { }
}

class BankAccount
{
    double balance = 5000;

    public void Withdraw(double amount)
    {
        if (amount < 0)
            throw new ArgumentException("Invalid amount!");

        if (amount > balance)
            throw new InsufficientFundsException("Insufficient balance!");

        balance -= amount;
        Console.WriteLine("Withdrawal successful, new balance: " + balance);
    }
}

class BankTransactionDemo
{
    static void Main()
    {
        try
        {
            BankAccount acc = new BankAccount();
            acc.Withdraw(6000);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
