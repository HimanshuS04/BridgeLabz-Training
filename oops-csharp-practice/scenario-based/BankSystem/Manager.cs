using System;
class Manager
{
   public void CreateAccount(Bank bank, int accountNo, string name, double initialDeposit)
{
    if (initialDeposit >= bank.minBalance)
    {
        bank.accountCount++;

        int index = bank.accountCount - 1;

        bank.accountDetails[index, 0] = accountNo;
        bank.accountName[index] = name;
        bank.accountDetails[index, 1] = initialDeposit;
        bank.isActive[index] = true;

        Console.WriteLine("Account created successfully for " + name);
    }
    else
    {
        Console.WriteLine("Initial deposit must be at least the minimum balance of " + bank.minBalance);
    }
}


    public void CloseAccount(Bank bank, int accountNo)
    {
        for (int i = 0; i < bank.accountCount; i++)
        {
            if (bank.accountDetails[i, 0] == accountNo && bank.isActive[i])
            {
                bank.isActive[i] = false;
                Console.WriteLine("Account number " + accountNo + " has been closed.");
                bank.accountCount--;
                return;
            }
        }
        Console.WriteLine("Account not found or already inactive.");
    }

    public void ViewAccountDetails(Bank bank, int accountNo)
    {
        for (int i = 0; i < bank.accountCount; i++)
        {
            if (bank.accountDetails[i, 0] == accountNo)
            {
                Console.WriteLine("Account Number: " + bank.accountDetails[i, 0]);
                Console.WriteLine("Account Holder: " + bank.accountName[i]);
                Console.WriteLine("Balance: " + bank.accountDetails[i, 1]);
                return;
            }
        }
        Console.WriteLine("Account not found");
    }
}
