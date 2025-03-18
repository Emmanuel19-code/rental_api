namespace app.Domain.Contract
{
    public class GetPropertyRequest
    {
        public double? MinPrice {get;set;}
        public double? MaxPrice {get;set;}
        public string Beds {get;set;}
        public int Baths {get;set;}
        public string PropertyType {get;set;}
        public double? MinSquareFeet {get;set;}
        public double? MaxSquareFeet {get;set;}
        public int Amenities {get;set;}
        public string AvailableFrom {get;set;}
        public double Latitude {get;set;}
        public double Longitute {get;set;}
    }
    public class Property
    {

    }
}