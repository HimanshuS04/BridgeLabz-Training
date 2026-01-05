using System;

public sealed class Bill : IPayable
{
    private readonly string _billNumber;
    private readonly Patient _patient;
    private readonly decimal _amount;
    private bool _isPaid;

    public decimal Amount => _amount;
    public bool IsPaid => _isPaid;

    public Bill(string billNumber, Patient patient, decimal amount)
    {
        if (string.IsNullOrWhiteSpace(billNumber))
            throw new ArgumentException("Bill number cannot be empty.");
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));
        if (amount < 0)
            throw new ArgumentException("Amount cannot be negative.");

        _billNumber = billNumber;
        _patient = patient;
        _amount = amount;
        _isPaid = false;
    }

    public void ProcessPayment()
    {
        if (_isPaid)
        {
            Console.WriteLine($"Bill {_billNumber} is already paid.");
            return;
        }

        _isPaid = true;
        Console.WriteLine($"Payment of ₹{_amount} processed for {_patient.Name}.");
    }

    public void PrintReceipt()
    {
        Console.WriteLine("\n=== Payment Receipt ===");
        Console.WriteLine($"Bill Number : {_billNumber}");
        Console.WriteLine($"Patient     : {_patient.Name}");
        Console.WriteLine($"Amount      : ₹{_amount}");
        Console.WriteLine($"Status      : {(_isPaid ? "PAID" : "UNPAID")}");
    }
}
