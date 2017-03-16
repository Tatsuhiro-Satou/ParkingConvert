using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingConvertJson.Model
{
    class Attributes 
    {
        public int OBJECTID { get; set; }
        public string GROEP { get; set; }
        public string TITEL { get; set; }
        public string ADRES { get; set; }
        public string POSTCODE { get; set; }
        public string PLAATS { get; set; }
        public string EMAIL { get; set; }
        public string WEBSITE { get; set; }
        public string STATUS { get; set; }
        public string GlobalID { get; set; }
        //public float? Shape_Area { get; set; }
        public int Shape_Area { get; set; }
        //public string Shape_Area { get; set; }
        public float? Shape_Length { get; set; }
        public long CreationDate { get; set; }
        public string Creator { get; set; }
        public long EditDate { get; set; }
        public string Editor { get; set; }
    }
}
