using Newtonsoft.Json;
using ParkingConvertJson.Controllers;
using ParkingConvertJson.Model;
using ParkingConvertJson.Parkingspace;
using ParkingConvertJson.Roadwork;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingConvertJson
{
    class ParkingApp
    {
        private DatabaseController databaseController;
        private RoadworksController roadworksController;
        private RoadworksLocationController roadworksLocationController;
        private ParkingspaceController parkingspaceController;

        public ParkingApp()
        {
            databaseController = new DatabaseController();
            roadworksController = new RoadworksController();
            roadworksLocationController = new RoadworksLocationController();
            parkingspaceController = new ParkingspaceController();
        }

        public void ConvertParkingspaces()
        {
            var json = new WebClient().DownloadString("https://geoservices.denhaag.nl/arcgis/rest/services/V2_0_Verkeer/Weg/MapServer/0/query?where=BORDTYPE_WAARDE%3D%27Algemene+gehandicaptenplaats%27&outFields=*&outSR=4326&f=json");
            ParkingspaceParent parkingspaceParent = JsonConvert.DeserializeObject<ParkingspaceParent>(json);

            foreach (var item in parkingspaceParent.features)
            {
                if (item.attributes.BORDTYPE_WAARDE != "Gereserveerde gehandicapten parkeerplaats" && 
                    item.attributes.BORDTYPE_WAARDE != "Gereserveerde ambassadeplaats" &&
                    item.attributes.BORDTYPE_WAARDE != "Gereserveerde verloskundige plaats" &&
                    item.attributes.BORDTYPE_WAARDE != "Gereserveerde artsenplaats" &&
                    item.attributes.BORDTYPE_WAARDE != "Gereserveerde plaats int. organisatie" &&
                    item.attributes.BORDTYPE_WAARDE != "Gereserveerde parkeerplaats" &&
                    item.attributes.BORDTYPE_WAARDE != "Gereserveerde ambassadeurplaats" &&
                    item.geometry != null)
                {
                    parkingspaceController.Insert
                    (
                        item.attributes.ID,
                        item.attributes.BORDTYPE_WAARDE,
                        item.attributes.ONDERBORDTYPE_WAARDE,
                        item.geometry.x,
                        item.geometry.y
                    );

                }
            }

        }

        public void ConvertRoadWorks()
        {
            var json = new WebClient().DownloadString("https://services7.arcgis.com/b8OtZx5E96LVMxxJ/arcgis/rest/services/Wegwerkzaamheden2017/FeatureServer/0/query?where=1%3D1&outFields=*&outSR=4326&f=json");
            ParentObject roadWorks = JsonConvert.DeserializeObject<ParentObject>(json);

            foreach (Features item in roadWorks.features)
            {
                roadworksController.Insert
                (
                   item.attributes.OBJECTID,
                   item.attributes.TITEL,
                   item.attributes.STATUS
                );

                foreach (var geometry in item.geometry.rings)
                {
                    foreach (var inner in geometry)
                    {
                        roadworksLocationController.Insert(item.attributes.OBJECTID, inner[0], inner[1]);
                    }
                }
            }

        }

    }
}
