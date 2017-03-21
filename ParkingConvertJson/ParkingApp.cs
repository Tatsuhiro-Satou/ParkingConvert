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
        public  RoadworksController roadworksController { get; set; }
        public RoadworksLocationController roadworksLocationController { get; set; }
        public ParkingspaceController parkingspaceController{ get; set; }

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
                        item.attributes.ONDERBORDTYPE_WAARDE,
                        item.geometry.x,
                        item.geometry.y
                    );

                }
            }

        }

        public void ConvertRoadWorks()
        {
            var json = new WebClient().DownloadString("https://services7.arcgis.com/b8OtZx5E96LVMxxJ/arcgis/rest/services/Wegwerkzaamheden2017_View/FeatureServer/0/query?where=1%3D1&outFields=*&outSR=4326&f=json");
            RoadworkParent roadworks = JsonConvert.DeserializeObject<RoadworkParent>(json);
            roadworks = MergeDuplicates(roadworks);

            foreach (RoadworkFeatures item in roadworks.features)
            {
                roadworksController.Insert
                (
                   item.attributes.OBJECTID,
                   item.attributes.TITEL,
                   item.attributes.STATUS
                );

                if (item.geometry.MergedData == null)
                {
                    foreach (var geometry in item.geometry.rings)
                    {
                        foreach (var inner in geometry)
                        {
                            roadworksLocationController.Insert(item.attributes.OBJECTID, inner[0], inner[1]);
                        }
                    }
                }
                else
                {
                    foreach (var pos in item.geometry.MergedData)
                    {
                        roadworksLocationController.Insert(item.attributes.OBJECTID, pos[0], pos[1]);
                    }

                }
            }

        }

        /// <summary>
        /// In het Roadwork json bestand kunnen meerdere unieke rows over dezelfde wegwerkzaamheid gaan. 
        /// Om duplicates in de DB te voorkomen voeg ik hier de locaties van deze rows bij elkaar bij 1 row en verwijder ik de duplicate.
        /// </summary>
        /// <param name="roadworks"></param>
        /// <returns></returns>
        public RoadworkParent MergeDuplicates(RoadworkParent roadworks)
        {
            for (int item = 0; item < roadworks.features.Count; item++)
            {
                for (int subItem = 0; subItem < roadworks.features.Count; subItem++)
                {
                    if ((roadworks.features[item].attributes.OBJECTID != roadworks.features[subItem].attributes.OBJECTID) && (roadworks.features[item].attributes.TITEL.Equals(roadworks.features[subItem].attributes.TITEL)))
                    {
                        roadworks.features[item].geometry.MergedData = new List<decimal[]>();
                        roadworks.features[item].geometry.MergedData = roadworks.features[item].geometry.rings[0].ToList();
                        roadworks.features[item].geometry.MergedData.AddRange(roadworks.features[subItem].geometry.rings[0]); 

                        roadworks.features.Remove(roadworks.features[subItem]);
                        subItem--;
                        item--;
                    }
                }

            }
            return roadworks;
        }

    }
}
