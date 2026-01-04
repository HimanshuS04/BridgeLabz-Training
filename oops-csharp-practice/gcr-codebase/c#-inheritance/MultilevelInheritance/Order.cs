
using System;
class Order
{
    public int OrderId;
    public string OrderDate;
}
class ShippedOrder : Order
{
    public string TrackingNumber;
}
class DeliveredOrder : ShippedOrder
{
    public string DeliveryDate;
    public void GetOrderStatus()
    {
        Console.WriteLine("Delivered on " + DeliveryDate);
    }
}
class Program
{
    static void Main()
    {
        DeliveredOrder d = new DeliveredOrder();
        d.DeliveryDate = "05-Jan";
        d.GetOrderStatus();
    }
}
