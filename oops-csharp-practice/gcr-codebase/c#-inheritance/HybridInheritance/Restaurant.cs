
using System;
interface Worker
{
    void PerformDuty();
}
class Person
{
    public string Name;
    public int Id;
}
class Chef : Person, Worker
{
    public void PerformDuty(){ Console.WriteLine("Cooking food"); }
}
class Waiter : Person, Worker
{
    public void PerformDuty(){ Console.WriteLine("Serving food"); }
}
class Program
{
    static void Main()
    {
        Chef c = new Chef();
        c.PerformDuty();
    }
}
