using ParkingConvertJson.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingConvertJson.Roadwork
{
    class RoadworkParent 
    {
        public string objectIdFieldName { get; set; }
        public string globalIdFieldName { get; set; }
        public GeometricProperties geometricProperties{ get; set; }
        public string geometryType { get; set; }
        public SpatialReference spatialReference { get; set; }
        public List<Field> fields { get; set; }
        public List<RoadworkFeatures> features { get; set; }

    }

    class RoadworkFeatures 
    {
        public Attributes attributes { get; set; }
        public Geometry geometry { get; set; }
    }

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

    class Geometry
    {
        public decimal[] [] [] rings { get; set; }
        // The MergedData list only gets used when a duplicate roadworks exists with different locations.
        // The list will then contain the coordinates of the original roadworks and the duplicate instance.
        public List<decimal[]> MergedData{ get; set; }
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
