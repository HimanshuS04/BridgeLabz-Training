using System;

interface ILoanable
{
    void ApplyForLoan();
    double CalculateLoanEligibility();
}

abstract class BankAccount
{
    private int accountNumber;
    protected double balance;

    public BankAccount(int acc, double bal)
    {
        accountNumber = acc;
        balance = bal;
    }

    public void Deposit(double amt)
    {
        balance += amt;
    }

    public void Withdraw(double amt)
    {
        balance -= amt;
    }

    public abstract double CalculateInterest();
}

class SavingsAccount : BankAccount, ILoanable
{
    public SavingsAccount(int acc, double bal)
        : base(acc, bal) { }

    public override double CalculateInterest()
    {
        return balance * 0.04;
    }

    public void ApplyForLoan()
    {
        Console.WriteLine("Loan Applied");
    }

    public double CalculateLoanEligibility()
    {
        return balance * 5;
    }
}
