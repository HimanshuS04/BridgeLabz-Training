
using System;
class BankAccount
{
    public int AccountNumber;
    public double Balance;
}
class SavingsAccount : BankAccount
{
    public double InterestRate;
    public void DisplayAccountType(){ Console.WriteLine("Savings"); }
}
class CheckingAccount : BankAccount
{
    public int WithdrawalLimit;
    public void DisplayAccountType(){ Console.WriteLine("Checking"); }
}
class FixedDepositAccount : BankAccount
{
    public int LockInPeriod;
    public void DisplayAccountType(){ Console.WriteLine("Fixed Deposit"); }
}
class Program
{
    static void Main()
    {
        SavingsAccount s = new SavingsAccount();
        s.DisplayAccountType();
    }
}
