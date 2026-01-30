using System;

public class UserInterface
{
    public static void Main()
    {
        Console.WriteLine("Enter the Goods Transport details");
        string input = Console.ReadLine();

        GoodsTransport gt = Utility.parseDetails(input);
        if (gt == null)
            return;

        Console.WriteLine("\nTransporter id : " + gt.TransportId);
        Console.WriteLine("Date of transport : " + gt.TransportDate);
        Console.WriteLine("Rating of the transport : " + gt.TransportRating);

        if (gt is BrickTransport)
        {
            BrickTransport bt = (BrickTransport)gt;
            Console.WriteLine("Quantity of bricks : " + bt.BrickQuantity);
            Console.WriteLine("Brick price : " + bt.BrickPrice);
        }
        else if (gt is TimberTransport)
        {
            TimberTransport tt = (TimberTransport)gt;
            Console.WriteLine("Type of the timber : " + tt.TimberType);
            Console.WriteLine("Timber price per kilo : " + tt.TimberPrice);
        }

        Console.WriteLine("Vehicle for transport : " + gt.vehicleSelection());
        Console.WriteLine("Total charge : " + gt.calculateTotalCharge());
    }
}
