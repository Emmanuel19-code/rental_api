using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace app.Domain.Entities
{
    public class Location
    {
        [Key]
        public string LocationId {get;set;}
        public string Address {get;set;}
        public string City {get;set;}
        public string State {get;set;}
        public string Country {get;set;}
        public string PostalCode {get;set;}
        public Point Coordinates {get;set;}

        public List<Property> Properties {get;set;} = new ();
    }
}