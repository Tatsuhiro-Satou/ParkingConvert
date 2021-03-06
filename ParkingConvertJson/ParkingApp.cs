﻿using Newtonsoft.Json;
using ParkingConvertJson.Controllers;
using System;
using System.Net;

namespace ParkingConvertJson
{
    class ParkingApp
    {
        private ParkingspaceController parkingspaceController;

        public ParkingApp()
        {
            parkingspaceController = new ParkingspaceController();

            parkingspaceController.Truncate();
            ConvertParkingspaces();
        }

        /// <summary>
        /// Download the parkingspace data from the internet and insert it into the database.
        /// </summary>
        private void ConvertParkingspaces()
        {
            dynamic parker = null;
            try
            {
                string json = new WebClient().DownloadString("https://geoservices.denhaag.nl/arcgis/rest/services/V2_0_Verkeer/Weg/MapServer/0/query?where=BORDTYPE_WAARDE%3D%27Algemene+gehandicaptenplaats%27&outFields=*&outSR=4326&f=json");
                parker = JsonConvert.DeserializeObject<dynamic>(json);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load data from parkingspaces");
            }

            foreach (dynamic item in parker.features)
            {
                // Some rows may not have geometry and should be rejected. Insert only parkingspaces accessible to the public.
                if ((item.attributes.BORDTYPE_WAARDE.ToString().Equals("Algemene gehandicaptenplaats")) && (item.geometry != null))
                {
                    parkingspaceController.Insert
                    (
                        (int)item.attributes.ID,
                        item.attributes.ONDERBORDTYPE_WAARDE.ToString(),
                        (decimal)item.geometry.x,
                        (decimal)item.geometry.y
                    );
                }
                else
                {
                    Console.WriteLine($"Unable to insert the parkingspace with ID: {item.attributes.ID} ");
                }
            }
        }
    }
}
