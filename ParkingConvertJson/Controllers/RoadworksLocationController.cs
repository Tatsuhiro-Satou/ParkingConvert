using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingConvertJson.Controllers
{
    class RoadworksLocationController : DatabaseController
    {
        //public List<RoadworkLocation> failed { get; set; }

        public RoadworksLocationController()
        {
            //failed = new List<RoadworkLocation>();
        }

        public void Insert(int roadworks, decimal longitude, decimal lattitude) // but don't let null floats in the database
        {
            string roadworksString = roadworks.ToString(CultureInfo.InvariantCulture);
            string longitudeString = longitude.ToString(CultureInfo.InvariantCulture);
            string lattitudeString = lattitude.ToString(CultureInfo.InvariantCulture);

            try
            {
                connection.Open();
                //query = $"INSERT INTO parkingspace(id, bord_type_waarde, onderbord_type, x, y) VALUES('{id}', '{bordtype_waarde}', '{onderbordtype_waarde}', '{x}', '{y}')";
                query = $"INSERT INTO roadworks_location(roadworks, longitude, lattitude) VALUES('{roadworksString}', '{longitudeString}', '{lattitudeString}')";
                sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
            }
            catch (Exception e)
            {
                //RoadworkLocation failedRecord = new RoadworkLocation();
                //failedRecord.Roadworks = roadworks;
                //failedRecord.Longitude = longitude;
                //failedRecord.Lattitude = lattitude;
                //failed.Add(failedRecord);
                //Console.WriteLine("ERROR" + e.ToString());
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
                    query = $"TRUNCATE TABLE roadworks_location";
                    sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR" + e.ToString());
                }
                finally
                {
                    connection.Close();
                }
        }

    }
}
