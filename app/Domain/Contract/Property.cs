namespace app.Domain.Contract
{
    public class GetPropertyRequest
{
    public string Location { get; set; }  // Matches filters.location
    public double? PriceMin { get; set; } // Matches priceRange?.[0]
    public double? PriceMax { get; set; } // Matches priceRange?.[1]
    public int? Beds { get; set; }  // Matches filters.beds (assuming it's an int)
    public int? Baths { get; set; } // Matches filters.baths (assuming it's an int)
    public string PropertyType { get; set; }
    public double? SquareFeetMin { get; set; } // Matches squareFeet?.[0]
    public double? SquareFeetMax { get; set; } // Matches squareFeet?.[1]
    public string Amenities { get; set; } // Comma-separated string to match `filters.amenities?.join(",")`
    public string AvailableFrom { get; set; } // Matches filters.availableFrom (assuming string)
    public string FavoriteIds { get; set; } // Comma-separated string to match `filters.favoriteIds?.join(",")`
    public double? Latitude { get; set; }  // Matches filters.coordinates?.[1]
    public double? Longitude { get; set; } // Matches filters.coordinates?.[0]
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