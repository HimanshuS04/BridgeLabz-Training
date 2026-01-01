using System;
class Customer
{
    public void Deposit(Bank bank, int accountNo, double amount )
    {
        for(int i = 0; i < bank.accountCount; i++)
        {
            if(bank.accountDetails[i,0]==accountNo && bank.isActive[i])
            {
                if(amount>0)
                {
                    bank.accountDetails[i,1]+=amount;
                    Console.WriteLine("Amount deposited successfully. New balance: " + bank.accountDetails[i,1]);
                    return;
                    
                }
                else{
                    Console.WriteLine("Invalid amount. Deposit failed.");
                    return;
                }
            }
        }
            Console.WriteLine("Account not found or inactive. Deposit failed.");
            return;


        
    }

    public void Withdraw(Bank bank,int accoutNo,double amount)
    {
        for(int i = 0; i < bank.accountCount; i++)
        {
            if(bank.accountDetails[i,0]==accoutNo && bank.isActive[i])
            {
                if(amount>0)
                {
                   if(bank.accountDetails[i,1]-amount>=bank.minBalance)
                    {
                        bank.accountDetails[i,1]-=amount;
                        Console.WriteLine("Amount withdraw succesfullt. New Balance is :"+bank.accountDetails[i,1]);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance. Withdrawal failed.");
                        return;
                    }
                }
                Console.WriteLine("Invalid amount. Withdrawal failed.");
                return;
            }
        }
        Console.WriteLine("Account not found or inactive. Withdrawal failed.");

    }
    public void CheckBalance(Bank bank, int accountNo)
    {
        Console.WriteLine("Checking balance for account number: " + accountNo);
        for(int i=0;i<bank.accountCount;i++)
        {
            if(bank.accountDetails[i,0]==accountNo && bank.isActive[i])
            {
                Console.WriteLine("Current balance: " + bank.accountDetails[i,1]);
                return;
            }

        }
         Console.WriteLine("Account not found or inactive. Contact Bank");

    }




}