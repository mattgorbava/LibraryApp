using Microsoft.Data.SqlClient;

namespace LibraryApp.Model.DataAccessLayer
{
    class DbHelper
    {
        public static SqlConnection Connection = new SqlConnection
            (@"Server=DESKTOP-ND1IOQ4;Database=UpdatedLibraryDB;Trusted_Connection=True;TrustServerCertificate=True");
    }
}
