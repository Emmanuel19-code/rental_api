using System.ComponentModel.DataAnnotations;
using app.Domain.Enums;

namespace app.Domain.Entities
{
    

    public class Property
    {
        [Key]
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public double PricePerMonth { get; set; }
        public double ApplicationFee { get; set; }
        public PropertyType PropertyType { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.UtcNow;
        public double? AverageRating { get; set; } = 0;
        public int? NumberOfReviews { get; set; } = 0;
        public List<PropertyPhotos> Photos { get; set; } = new List<PropertyPhotos>();
        public List<Amenities> Amenities { get; set; } = new List<Amenities>();
        public List<HighLight> HighLights { get; set; } = new List<HighLight>();

        public bool IsParkingIncluded { get; set; }
        public bool IsPetsAllowed { get; set; }
        public int Beds { get; set; }
        public double SquareFeet { get; set; }
        public double Baths { get; set; }

        public string ManagerCognitoId {get;set;}
        public string LocationId {get;set;}

        List<Amenities> Amenity {get;set;} = new ();

        public Location Location {get;set;}
        public Manager Manager {get;set;}
    }

}