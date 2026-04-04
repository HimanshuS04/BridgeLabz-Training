using System;
using Microsoft.Data.SqlClient;

class DataConfig
{
    
    public static string ConnectionString =
        "Server=127.0.0.1,1433;" +
        "Database=practice_db;" +
        "User Id=sa;" +
        "Password=Ms@12345;" +
        "Encrypt=False;" +
        "TrustServerCertificate=True;";

    public static SqlConnection GetConnection()
    {
        SqlConnection connection= new SqlConnection(ConnectionString);
        connection.Open();
        Console.WriteLine("Connection Established Succersfully");
        return connection;
    }
}
