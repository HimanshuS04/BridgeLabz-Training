using System;

class BankAccount
{
    public static string BankName = "State Bank";
    private static int totalAccounts = 0;

    public string AccountHolderName;
    public readonly int AccountNumber;

    public BankAccount(string AccountHolderName, int AccountNumber)
    {
        this.AccountHolderName = AccountHolderName;
        this.AccountNumber = AccountNumber;
        totalAccounts++;
    }

    public static void GetTotalAccounts()
    {
        Console.WriteLine("Total Accounts: " + totalAccounts);
    }

    public void Display(object obj)
    {
        if (obj is BankAccount)
        {
            Console.WriteLine(AccountHolderName + " - " + AccountNumber);
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc1 = new BankAccount("Amit", 101);
        BankAccount acc2 = new BankAccount("Rahul", 102);
        BankAccount acc3 = new BankAccount("Sneha", 103);


        acc1.Display(acc1);
        acc2.Display(acc2);
        acc3.Display(acc3);
        BankAccount.GetTotalAccounts();
    }
}
