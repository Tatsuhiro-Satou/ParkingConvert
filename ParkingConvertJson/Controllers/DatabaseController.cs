using ParkingConvertJson.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingConvertJson.Controllers
{
    class DatabaseController
    {
        protected SqlConnection connection;
        protected SqlCommand sqlCommand;
        protected string query;

        public DatabaseController()
        {
            connection = new SqlConnection();
            connection.ConnectionString =
            "Data Source=localhost\\SQLEXPRESS;" +
            "Initial Catalog=parkingapp;" +
            "Integrated Security=SSPI;";
        }
    }
}
