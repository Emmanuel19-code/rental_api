namespace app.Domain.Entities
{
    public class PropertyPhotos
    {
        public Guid Id {get;set;}
        public string LocationId {get;set;}
        public string PhotoUrl {get;set;}

        public Property Property {get;set;}
    }
}