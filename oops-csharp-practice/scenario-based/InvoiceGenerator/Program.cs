using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter invoice details:");
        string input = Console.ReadLine();

        Invoice invoice = new Invoice(10);
        invoice.ParseInvoice(input);
        invoice.DisplayInvoice();

        int total = invoice.GetTotalAmount();
        Console.WriteLine("\nTotal Amount = " + total + " INR");
    }
}
