using System.Data.SqlClient;

namespace ParkingConvertJson.Controllers
{
    class DatabaseController
    {
        protected SqlConnection connection;
        protected SqlCommand sqlCommand;
        protected string query;
        protected string filePath;

        public DatabaseController()
        {
            filePath = @"..\..\..\error_log.txt";
            connection = new SqlConnection();
            connection.ConnectionString =
            "Data Source=localhost\\SQLEXPRESS;" +
            "Initial Catalog=parkingapp;" +
            "Integrated Security=SSPI;";
        }
    }
}
