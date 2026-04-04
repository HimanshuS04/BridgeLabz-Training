using System;
class Manager
{
   public void CreateAccount(Bank bank, int accountNo, string name, double initialDeposit)
    {
        if (initialDeposit < bank.minBalance)
        {
            Console.WriteLine("Initial deposit must be at least " + bank.minBalance);
            return;
        }

        for (int i = 0; i < bank.accountCount; i++)
        {
            if (!bank.isActive[i])
            {
                bank.accountDetails[i, 0] = accountNo;
                bank.accountDetails[i, 1] = initialDeposit;
                bank.accountName[i] = name;
                bank.isActive[i] = true;

                Console.WriteLine("Account created successfully for " + name);
                return;
            }
        }

        Console.WriteLine("Account limit reached. Cannot create more accounts.");
    }


    public void CloseAccount(Bank bank, int accountNo)
    {
        for (int i = 0; i < bank.accountCount; i++)
        {
            if (bank.accountDetails[i, 0] == accountNo && bank.isActive[i])
            {
                bank.isActive[i] = false;
                Console.WriteLine("Account number " + accountNo + " has been closed.");
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
