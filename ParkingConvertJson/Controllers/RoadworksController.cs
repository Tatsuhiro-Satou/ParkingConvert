using ParkingConvertJson.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingConvertJson.Controllers
{
    class RoadworksController : DatabaseController
    {
        public List<Features> failed { get; set; }

        public RoadworksController()
        {
            failed = new List<Features>();
        }

        public void Insert(int id_roadworks, string description, string status) // but don't let null floats in the database
        {
            try
            {
                connection.Open();
                //query = $"INSERT INTO parkingspace(id, bord_type_waarde, onderbord_type, x, y) VALUES('{id}', '{bordtype_waarde}', '{onderbordtype_waarde}', '{x}', '{y}')";
                query = $"INSERT INTO roadworks(id_roadworks, description, status) VALUES('{id_roadworks}', '{description}', '{status}')";
                sqlCommand = new SqlCommand(query, connection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
            }
            catch (Exception e)
            {
                Features failedRecord = new Features();
                failedRecord.attributes = new Attributes();
                failedRecord.attributes.GlobalID = id_roadworks.ToString();
                failedRecord.attributes.TITEL = description;
                failedRecord.attributes.STATUS = status;
                failed.Add(failedRecord);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
