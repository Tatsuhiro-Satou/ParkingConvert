using ParkingConvertJson.Model;
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
        public List<RoadworkLocation> failedRoadworkLocations { get; set; }

        public RoadworksLocationController()
        {
            failedRoadworkLocations = new List<RoadworkLocation>();
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
                RoadworkLocation failed = new RoadworkLocation();
                failed.Roadworks = roadworks;
                //failed.Longitude = longitude;
                //failed.Lattitude = lattitude;
                failedRoadworkLocations.Add(failed);
                Console.WriteLine("ERROR" + e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
