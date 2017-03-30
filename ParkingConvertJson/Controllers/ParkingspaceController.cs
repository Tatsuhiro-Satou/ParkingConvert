using System;
using System.Data.SqlClient;
using System.Globalization;

namespace ParkingConvertJson.Controllers
{
    class ParkingspaceController : DatabaseController
    {
        /// <summary>
        /// Insert the JSON data into the database.
        /// </summary>
        /// <param name="id">ID of the parkingspace</param>
        /// <param name="onderbordtype_waarde">Sign type</param>
        public void Insert(int id, string onderbordtype_waarde, decimal longitude, decimal lattitude) // but don't let null floats in the database
        {
            string longitudeString = longitudeString = longitude.ToString(CultureInfo.InvariantCulture);
            string lattitudeString = lattitudeString = lattitude.ToString(CultureInfo.InvariantCulture);

            try
            {
                connection.Open();
                query = $"INSERT INTO parkingspace(id, sign_type, longitude, lattitude) VALUES('{id}', '{onderbordtype_waarde}', '{longitudeString}', '{lattitudeString}')";
                sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unable to insert {id}");
                Console.WriteLine("ERROR" + e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Removes all rows of this table.
        /// </summary>
        public void Truncate()
        {
                try
                {
                    connection.Open();
                    query = $"TRUNCATE TABLE parkingspace";
                    sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Was unable to truncate the Parkingspace table");
                    Console.WriteLine("ERROR" + e.ToString());
                }
                finally
                {
                    connection.Close();
                }
        }
    }
}
