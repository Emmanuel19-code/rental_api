using System.Linq;
using app.Domain.Contract;
using app.Infrastructure;

namespace app.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _dbContext;
        public PropertyService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse<PropertyResponse>> CreateProperty(CreatePropertyRequest request)
        {
            Console.WriteLine(request.PropertyData);
            var property = new PropertyResponse
            {

            };
            return new ApiResponse<PropertyResponse>(property, "done");
        }

        public async Task<ApiResponse<PropertyResponse>> GetAllProperties(GetPropertyRequest request)
        {
            Console.WriteLine($"Location: {request.Location}");
            Console.WriteLine($"PriceMin: {request.PriceMin}");
            Console.WriteLine($"PriceMax: {request.PriceMax}");
            Console.WriteLine($"Beds: {request.Beds}");
            Console.WriteLine($"Baths: {request.Baths}");
            Console.WriteLine($"PropertyType: {request.PropertyType}");
            Console.WriteLine($"SquareFeetMin: {request.SquareFeetMin}");
            Console.WriteLine($"SquareFeetMax: {request.SquareFeetMax}");
            Console.WriteLine($"Amenities: {request.Amenities}");
            Console.WriteLine($"AvailableFrom: {request.AvailableFrom}");
            Console.WriteLine($"FavoriteIds: {request.FavoriteIds}");
            Console.WriteLine($"Latitude: {request.Latitude}");
            Console.WriteLine($"Longitude: {request.Longitude}");

            var query = _dbContext.Property.AsQueryable();

            // Price filtering
            if (request.PriceMax.HasValue)
            {
                query = query.Where(p => p.PricePerMonth <= request.PriceMax);
            }
            if (request.PriceMin.HasValue)
            {
                query = query.Where(p => p.PricePerMonth >= request.PriceMin);
            }

            // Beds filtering
            if (request.Beds.HasValue && request.Beds > 0)
            {
                query = query.Where(p => p.Beds >= request.Beds);
            }

            // Baths filtering
            if (request.Baths.HasValue && request.Baths > 0)
            {
                query = query.Where(p => p.Baths >= request.Baths);
            }

            // SquareFeet filtering
            if (request.SquareFeetMax.HasValue)
            {
                query = query.Where(p => p.SquareFeet <= request.SquareFeetMax);
            }
            if (request.SquareFeetMin.HasValue)
            {
                query = query.Where(p => p.SquareFeet >= request.SquareFeetMin);
            }

            // Property Type filtering
            if (!string.IsNullOrEmpty(request.PropertyType) &&
                !request.PropertyType.Equals("any", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(p =>p.PropertyType.Equals(request.PropertyType));
            }

            // Amenities filtering (comma-separated string to list)
            //if (!string.IsNullOrEmpty(request.Amenities))
            //{
            //    var amenityIds = request.Amenities.Split(',')
            //                                       .Select(a => int.TryParse(a, out var id) ? id : (int?)null)
            //                                       .Where(id => id.HasValue)
            //                                       .Select(id => id.Value)
            //                                       .ToList();
//
            //    if (amenityIds.Any())
            //    {
            //        query = query.Where(p => p.Amenities.Any(a => amenityIds.Contains(a.Id))); // Assuming Property has `Amenities`
            //    }
            //}
//
            //// AvailableFrom filtering (assuming it’s a valid date)
            //if (!string.IsNullOrEmpty(request.AvailableFrom) &&
            //    DateTime.TryParse(request.AvailableFrom, out var availableDate))
            //{
            //    query = query.Where(p => p.AvailableFrom >= availableDate);
            //}

            // Latitude & Longitude filtering (if needed, adjust range based on actual logic)
            //if (request.Latitude.HasValue && request.Longitude.HasValue)
            //{
            //    double radius = 0.1; // Example small range
            //    query = query.Where(p =>
            //        p.Latitude >= request.Latitude - radius && p.Latitude <= request.Latitude + radius &&
            //        p.Longitude >= request.Longitude - radius && p.Longitude <= request.Longitude + radius);
            //}
//
            //// Favorite IDs filtering (comma-separated string to list)
            //if (!string.IsNullOrEmpty(request.FavoriteIds))
            //{
            //    var favoriteIds = request.FavoriteIds.Split(',')
            //                                         .Select(id => int.TryParse(id, out var parsedId) ? parsedId : (int?)null)
            //                                         .Where(id => id.HasValue)
            //                                         .Select(id => id.Value)
            //                                         .ToList();
//
            //    if (favoriteIds.Any())
            //    {
            //        query = query.Where(p => favoriteIds.Contains(p.Id)); // Assuming Property has `Id`
            //    }
            //}
//
            //// Fetch filtered properties
            //var properties = await query.ToListAsync();
//
            //if (!properties.Any())
            //{
            //    return new ApiResponse<List<Property>>(null, "No properties found.");
            //}
                var properties = new PropertyResponse
                {

                };
            return new ApiResponse<PropertyResponse>(properties, "Properties retrieved successfully.");
        }



        public Task<ApiResponse<PropertyResponse>> GetProperty(string id)
        {
            throw new NotImplementedException();
        }

        private async Task<string> UploadFile(IFormFile profileImage)
        {
            string filePath = string.Empty;
            if (profileImage != null)
            {
                var imageFolderPath = Path.Combine("Upload", "images");
                Directory.CreateDirectory(imageFolderPath);
                var imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(profileImage.FileName);
                filePath = Path.Combine(imageFolderPath, imageFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await profileImage.CopyToAsync(stream);
                }
            }
            return filePath;
        }
    }
}