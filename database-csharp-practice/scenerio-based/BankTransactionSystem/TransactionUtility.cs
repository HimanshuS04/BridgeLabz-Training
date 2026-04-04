using System;
using Microsoft.Data.SqlClient;

public class TransactionUtility : ITransactionService
{
    private string connectionString = "Server=127.0.0.1,1433;" +
        "Database=Bank;" +
        "User Id=sa;" +
        "Password=Ms@12345;" +
        "Encrypt=False;" +
        "TrustServerCertificate=True;";

    public void Withdraw(int accountId, decimal amount)
    {

        if (!CacheManager.Accounts.ContainsKey(accountId))
        {
            Console.WriteLine("Account Not Found");
            return;
        }

        Account acc = CacheManager.Accounts[accountId];

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                if (!acc.Withdraw(amount))
                    throw new Exception("Insufficient Balance");

                UpdateBalance(accountId, amount, conn, transaction);
                InsertTransaction(accountId, amount, "Withdraw", conn, transaction);

                transaction.Commit();
                Console.WriteLine("Withdrawal Success");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("Transaction Failed: " + ex.Message);
            }
        }
    }
private void UpdateBalance(int accountId, decimal amount,
        SqlConnection conn, SqlTransaction transaction)
    {
        string query =
            "UPDATE Accounts SET Balance = Balance - @amt WHERE AccountId=@id";

        SqlCommand cmd = new SqlCommand(query, conn, transaction);
        cmd.Parameters.AddWithValue("@amt", amount);
        cmd.Parameters.AddWithValue("@id", accountId);
        cmd.ExecuteNonQuery();
    }

    private void InsertTransaction(int accountId, decimal amount, string type,
        SqlConnection conn, SqlTransaction transaction)
    {
        string query =
            "INSERT INTO Transactions(AccountId,Amount,Type,CreatedDate) " +
            "VALUES(@id,@amt,@type,GETDATE())";

        SqlCommand cmd = new SqlCommand(query, conn, transaction);
        cmd.Parameters.AddWithValue("@id", accountId);
        cmd.Parameters.AddWithValue("@amt", amount);
        cmd.Parameters.AddWithValue("@type", type);
        cmd.ExecuteNonQuery();
    }
}