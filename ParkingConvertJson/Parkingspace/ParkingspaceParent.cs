using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingConvertJson.Parkingspace
{
    class ParkingspaceParent 
    {
        public string displayFieldName { get; set; }
        public fieldAlias fieldAliases { get; set; }
        public string geometryType { get; set; }
        public List<Field> fields { get; set; }
        public List<Feature> features { get; set; }
    }

    class fieldAlias
    {
        public string ID { get; set; }
        public string NAAM { get; set; }
        public string STATUS_WAARDE { get; set; }
        public string BORDTYPE_WAARDE { get; set; }
        public string ONDERBORDTYPE_WAARDE { get; set; }
        public string DRAGERTYPE_WAARDE { get; set; }
        public string VERGUNNINGGEBIED_NAAM { get; set; }
    }

    class spatialReference
    {
        public int wkid { get; set; }
        public int latestWkid { get; set; }
    }

    class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public string alias { get; set; }
        public int length { get; set; }
    }

    class Attributes
    {
        public int ID { get; set; }
        public string NAAM { get; set; }
        public string STATUS_WAARDE { get; set; }
        public string BORDTYPE_WAARDE{ get; set; }
        public string ONDERBORDTYPE_WAARDE{ get; set; }
        public string DRAGERTYPE_WAARDE { get; set; }
        public string VERGUNNINGGEBIED_NAAM { get; set; }
    }

    class Feature
    {
        public Attributes attributes { get; set; }
        public Geometry geometry { get; set; }
    }

    class Geometry
    {
        public float? x { get; set; }
        public float? y { get; set; }
    }

}
