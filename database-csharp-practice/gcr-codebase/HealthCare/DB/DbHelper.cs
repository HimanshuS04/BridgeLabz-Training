using Microsoft.Data.SqlClient;

namespace HealthCare.DB
{
    public static class DbHelper
    {
        private static readonly string appConnection =
            "Server=127.0.0.1,1433;" +
            "Database=HealthCareDB;" +
            "User Id=sa;" +
            "Password=Ms@12345;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        private static readonly string masterConnection =
            "Server=127.0.0.1,1433;" +
            "Database=master;" +
            "User Id=sa;" +
            "Password=Ms@12345;" +
            "Encrypt=False;" +
            "TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(appConnection);
            conn.Open();
            return conn;
        }

        public static SqlConnection GetMasterConnection()
        {
            var conn = new SqlConnection(masterConnection);
            conn.Open();
            return conn;
        }
    }
}
