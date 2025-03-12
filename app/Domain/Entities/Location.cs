using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace app.Domain.Entities
{
    public class Location
    {
        [Key]
        public string LocationId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        [NotMapped] // Ignore UserData
        public object CoordinatesUserData
        {
            get => Coordinates?.UserData;
            set { if (Coordinates != null) Coordinates.UserData = value; }
        }

        public Point Coordinates { get; set; }

        public List<Property> Properties { get; set; } = new();
    }
}
