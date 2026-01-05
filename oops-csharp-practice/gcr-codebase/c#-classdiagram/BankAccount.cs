using System;

class Customer
{
    public string Name { get; set; }
    public double Balance { get; private set; }

    public Customer(string name)
    {
        Name = name;
    }

    public void ViewBalance()
    {
        Console.WriteLine($"{Name}'s Balance: ₹{Balance}");
    }

    public void SetBalance(double amount)
    {
        Balance = amount;
    }
}

class BankAccount
{
    public string BankName { get; set; }
    public List<Customer> Customers { get; set; } = new List<Customer>();

    public BankAccount(string name)
    {
        BankName = name;
    }

    public void OpenAccount(Customer customer, double initialAmount)
    {
        customer.SetBalance(initialAmount);
        Customers.Add(customer);
        Console.WriteLine($"Account opened for {customer.Name} in {BankName}");
    }
}

class Program
{
    static void Main()
    {
    BankAccount bank = new BankAccount("HDFC Bank");
        Customer c1 = new Customer("Alice");

        bank.OpenAccount(c1, 5000);
        c1.ViewBalance();
    }
}
