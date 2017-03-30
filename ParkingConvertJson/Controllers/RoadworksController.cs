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
        //public List<RoadworkParent> failed { get; set; }

        public RoadworksController()
        {
            //failed = new List<RoadworkParent>();
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
                //RoadworkParent failedRecord = new RoadworkParent();
                //failedRecord.Features = new List<RoadworkFeatures>();
                //failedRecord.Features.Add(new RoadworkFeatures());
                //failedRecord.Features[0].attributes = new Attributes();
                //failedRecord.Features[0].attributes.GlobalID = id_roadworks.ToString();
                //failedRecord.Features[0].attributes.TITEL = description;
                //failedRecord.Features[0].attributes.STATUS = status;
                //failed.Add(failedRecord);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Removes all rows of this table.
        /// Geeft een error, maar dat geeft niets.
        /// </summary>
        public void Truncate()
        {
                try
                {
                    connection.Open();
                    query = $"DELETE FROM roadworks DBCC CHECKIDENT ('roadworks', RESEED, 0)";
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
