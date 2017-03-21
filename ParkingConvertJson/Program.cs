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
        /// <summary>
        /// Runnen als je de nieuwste gegevens wilt ophalen.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ParkingApp parkingApp = new ParkingApp();

            parkingApp.parkingspaceController.Truncate();
            parkingApp.ConvertParkingspaces();

            parkingApp.roadworksController.Truncate();
            parkingApp.roadworksLocationController.Truncate();
            parkingApp.ConvertRoadWorks();

            //parkingApp.roadworksController.Truncate();

            Debugger.Break();
        }
    }
}

/*
## Methodes ##
Truncate: Table legen
Convert: Convert de json data naar de DB

## Bekende errors: ##
De errors kunnen geen kwaad, de eerst error heeft te maken met de table deleten en dat gaat gewoon goed.
De andere errors hebben allemaal te maken met duplicate rows. Sommige wegwerkzaamheid hebben altijd 1x duplicate coordinaten, 
dit zijn de coordinaten die het begin en einde markeren (dus hetzelfde zijn). 
Stel een cirkel voor, aan het einde kom je weer bij het begin en dat gebeurt hier ook.

*/
