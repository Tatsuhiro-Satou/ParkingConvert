using ParkingConvertJson.Parkingspace;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingConvertJson.Controllers
{
    class ParkingspaceController : DatabaseController
    {
        public List<ParkingspaceParent> failed { get; set; }

        public ParkingspaceController()
        {
            failed = new List<ParkingspaceParent>();
        }

        public void Insert(int id, string bordtype_waarde, string onderbordtype_waarde, float? longitude, float? lattitude) // but don't let null floats in the database
        {
            string longitudeString = "";
            string lattitudeString = "";
            if (longitude != null && lattitude != null)
            {
                float tempLongitude = (float)longitude;
                float tempLattitude = (float)lattitude;
                longitudeString = tempLongitude.ToString(CultureInfo.InvariantCulture);
                lattitudeString = tempLattitude.ToString(CultureInfo.InvariantCulture);

                try
                {
                    connection.Open();
                    query = $"INSERT INTO parkingspace(id, bord_type_waarde, onderbord_type, longitude, lattitude) VALUES('{id}', '{bordtype_waarde}', '{onderbordtype_waarde}', '{longitudeString}', '{lattitudeString}')";
                    sqlCommand = new SqlCommand(query, connection);
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Dispose();
                }
                catch (Exception e)
                {
                    ParkingspaceParent failedRecord = new ParkingspaceParent();
                    failedRecord.features = new List<Feature>();
                    failedRecord.features.Add(new Feature());
                    failedRecord.features[0].attributes = new Attributes();
                    failedRecord.features[0].geometry = new Geometry();
                    failedRecord.features[0].attributes.ID = id;
                    failedRecord.features[0].attributes.BORDTYPE_WAARDE = bordtype_waarde;
                    failedRecord.features[0].attributes.ONDERBORDTYPE_WAARDE = onderbordtype_waarde;
                    if (failedRecord.features[0].geometry != null)
                    {
                        failedRecord.features[0].geometry.x = longitude;
                        failedRecord.features[0].geometry.y = lattitude;
                    }
                    failed.Add(failedRecord);
                    Console.WriteLine("ERROR" + e.ToString());
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
