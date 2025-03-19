namespace app.Domain.Contract
{
    public class GetPropertyRequest
    {
        public double? MinPrice {get;set;}
        public double? MaxPrice {get;set;}
        public string Beds {get;set;}
        public string Baths {get;set;}
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
    public class CreatePropertyRequest
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ManagerCognitoId { get; set; }
        public Dictionary<string, object> PropertyData { get; set; }
}

}