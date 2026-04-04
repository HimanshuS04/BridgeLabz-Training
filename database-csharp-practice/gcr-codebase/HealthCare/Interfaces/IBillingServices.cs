namespace HealthCare.Interfaces
{
    public interface IBillingServices
    {
        void GenerateBill();
        void ViewBillDetails();
        void MakePayment();
        void ViewPaymentHistory();

    }
}