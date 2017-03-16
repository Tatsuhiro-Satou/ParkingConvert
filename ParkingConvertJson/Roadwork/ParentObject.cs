using ParkingConvertJson.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingConvertJson.Roadwork
{
    class ParentObject
    {
        public string objectIdFieldName { get; set; }
        public string globalIdFieldName { get; set; }
        public GeometricProperties geometricProperties{ get; set; }
        public string geometryType { get; set; }
        public SpatialReference spatialReference { get; set; }
        public List<Field> fields { get; set; }
        public List<Features> features { get; set; }
    }

    class GeometricProperties
    {
        public string shapeAreaFieldName { get; set; }
        public string shapeLengthFieldName { get; set; }
        public string unit { get; set; }
    }
    class SpatialReference
    {
        public int wkid { get; set; }
        public int latestWkid { get; set; }
    }

    class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public string alias { get; set; }
        public string sqlType { get; set; }
        public int length { get; set; }
        public Domain domain { get; set; }
        public string defaultValue { get; set; }

    }
    class Domain
    {
        public string type { get; set; }
        public string name { get; set; }
        public List<CodedValues> codedValues { get; set; }
    }
    class CodedValues
    {
        public string name { get; set; }
        public string code { get; set; } 
    }
}
