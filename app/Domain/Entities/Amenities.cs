namespace app.Domain.Entities
{
    public class Amenities
    {
        public Guid Id {get;set;}
        public string Amenity {get;set;}

        public Property Property {get;set;}
    }
}