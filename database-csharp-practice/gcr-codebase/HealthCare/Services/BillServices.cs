using System;
using System.Data;
using Microsoft.Data.SqlClient;
using HealthCare.DB;
using HealthCare.Exceptions;
using HealthCare.Interfaces;

namespace HealthCare.Services
{
    public class BillServices : IBillingServices
    {
        public void GenerateBill()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_insert_bill", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Visit ID: ");
            cmd.Parameters.AddWithValue("@visit_id", int.Parse(Console.ReadLine()));

            Console.Write("Patient ID: ");
            cmd.Parameters.AddWithValue("@patient_id", int.Parse(Console.ReadLine()));

            Console.Write("Doctor ID: ");
            cmd.Parameters.AddWithValue("@doctor_id", int.Parse(Console.ReadLine()));

            Console.Write("Amount: ");
            cmd.Parameters.AddWithValue("@total_amount", decimal.Parse(Console.ReadLine()));

            object id = cmd.ExecuteScalar();
            if (id == null) throw new ClinicException("Bill creation failed.");

            Console.WriteLine($"✅ Bill generated (ID: {id})");
        }

        public void ViewBillDetails()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM bills", conn);

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"Bill #{r["bill_id"]} - {r["payment_status"]}");
            }
        }

        public void MakePayment()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("sp_insert_payment_transaction", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            Console.Write("Bill ID: ");
            cmd.Parameters.AddWithValue("@bill_id", int.Parse(Console.ReadLine()));

            Console.Write("Amount: ");
            cmd.Parameters.AddWithValue("@amount_paid", decimal.Parse(Console.ReadLine()));

            Console.Write("Mode: ");
            cmd.Parameters.AddWithValue("@payment_mode", Console.ReadLine());

            object id = cmd.ExecuteScalar();
            if (id == null) throw new ClinicException("Payment failed.");

            Console.WriteLine("✅ Payment completed");
        }

        public void ViewPaymentHistory()
        {
            using SqlConnection conn = DbHelper.GetConnection();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM payment_transactions", conn);

            using SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"Txn {r["transaction_id"]} - {r["amount_paid"]}");
            }
        }
    }
}
