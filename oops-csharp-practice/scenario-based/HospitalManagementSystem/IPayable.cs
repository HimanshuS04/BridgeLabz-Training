public interface IPayable
{
    decimal Amount {get; }
    bool IsPaid{get ;}
    void ProcessPayment();
    void PrintReceipt();
}