using System;

class BankAccount
{
    public int accountNumber;
    protected string accountHolder;
    private double balance;

    public void SetBalance(double b)
    {
        balance = b;
    }

    public double GetBalance()
    {
        return balance;
    }
}

class SavingsAccount : BankAccount
{
    public void DisplayAccount()
    {
        Console.WriteLine("Account No : " + accountNumber);
        Console.WriteLine("Holder     : " + accountHolder);
    }

    static void Main()
    {
        SavingsAccount sa = new SavingsAccount();
        sa.accountNumber = 12345;
        sa.accountHolder = "Rahul Singh";
        sa.SetBalance(20000);

        sa.DisplayAccount();
        Console.WriteLine("Balance: " + sa.GetBalance());
    }
}
