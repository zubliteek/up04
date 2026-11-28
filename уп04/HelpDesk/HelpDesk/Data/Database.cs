using System.Data.SqlClient;

namespace HelpDesk.Data
{
    public static class Database
    {
        public static string ConnectionString =
            @"Server=localhost\SQLEXPRESS;
              Database=HelpDesk_Rubanik;
              Trusted_Connection=True;
              TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}