using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using ParkingConvertJson.Model;
using System.Diagnostics;
using ParkingConvertJson.Controllers;

namespace ParkingConvertJson
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingApp parkingApp = new ParkingApp();

            //parkingApp.ConvertParkingspaces();
            parkingApp.ConvertRoadWorks();

            Debugger.Break();
        }
    }
}

/*
NOTE:
in google maps voer je in:
52.0981941, 4.30815649
In de arcgis map voer je het andersom in:
4.30815649, 52.0981941
*/
