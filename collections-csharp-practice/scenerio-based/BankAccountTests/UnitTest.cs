using NUnit.Framework;
using System;

[TestFixture]
public class UnitTest
{
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(1000);
        account.Deposit(500);
        Assert.That(account.Balance, Is.EqualTo(1500));
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(1000);
        var ex = Assert.Throws<Exception>(() => account.Deposit(-100));
        Assert.That(ex.Message, Is.EqualTo("Deposit amount cannot be negative"));
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(1000);
        account.Withdraw(400);
        Assert.That(account.Balance, Is.EqualTo(600));
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(500);
        var ex = Assert.Throws<Exception>(() => account.Withdraw(700));
        Assert.That(ex.Message, Is.EqualTo("Insufficient funds."));
    }
}
