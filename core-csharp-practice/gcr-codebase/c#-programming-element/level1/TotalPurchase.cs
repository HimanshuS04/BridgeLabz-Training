using System;

class TotalPurchase
{
    static void Main(string[] args)
    {

        // Input
        double unitPrice = Convert.ToDouble(Console.ReadLine());

        int quantity = Convert.ToInt32(Console.ReadLine());

        // Calculate total price
        double totalPrice = unitPrice * quantity;

        // Output
        Console.WriteLine("The total purchase price is INR " + totalPrice + " if the quantity " + quantity + " and unit price is INR " + unitPrice);
    }
}
