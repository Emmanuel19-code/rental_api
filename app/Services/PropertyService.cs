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

        public async Task<ApiResponse<Property>> CreateProperty(CreatePropertyRequest request)
        {
            Console.WriteLine(request.PropertyData);
            var property = new Property
             {

             };
            return new ApiResponse<Property>(property,"done");
        }

        public async Task<ApiResponse<Property>> GetProperties(GetPropertyRequest request)
        {
            var query = _dbContext.Property.AsQueryable();
            if (request.MaxPrice.HasValue)
            {
                query = query.Where(p => p.PricePerMonth <= request.MaxPrice);
            }
            if (request.MinPrice.HasValue)
            {
                query = query.Where(p => p.PricePerMonth >= request.MinPrice);
            }
            int beds = 0;
            if (!string.IsNullOrEmpty(request.Beds) &&
                int.TryParse(request.Beds, out var parsedBeds) &&
                !request.Beds.Equals("any", StringComparison.OrdinalIgnoreCase))
            {
                beds = parsedBeds;
            }

            if (beds > 0)
            {
                query = query.Where(p => p.Beds >= beds);
            }
            if(request.MaxSquareFeet.HasValue)
            {
                query = query.Where(p=>p.SquareFeet<= request.MaxSquareFeet);
            }
            if(request.MinSquareFeet.HasValue)
            {
                query = query.Where(p=>p.SquareFeet>= request.MinSquareFeet);
            }
            
            int baths =0;
            if(!string.IsNullOrEmpty(request.Baths) && int.TryParse(request.Baths, out var parsedBaths) && !request.Baths.Equals("any",StringComparison.OrdinalIgnoreCase))
             {
                baths = parsedBaths;
             }
             if(beds > 0)
             {
                query = query.Where(p=>p.Baths >= baths);
             }
             if(!string.IsNullOrEmpty(request.PropertyType) && !request.PropertyType.Equals("any",StringComparison.OrdinalIgnoreCase))
             {
                query = query.Where(p=>p.PropertyType.Equals(request.PropertyType));
             }
             var properties = new Property
            {

            };
            return new ApiResponse<Property>(properties,"not found");
        }

        public Task<ApiResponse<Property>> GetProperty(string id)
        {
            throw new NotImplementedException();
        }

        private async Task<string> UploadFile(IFormFile profileImage)
        {
            string filePath = string.Empty;
            if(profileImage != null)
            {
                var imageFolderPath = Path.Combine("Upload","images");
                Directory.CreateDirectory(imageFolderPath);
                var imageFileName = Guid.NewGuid().ToString() + Path.GetExtension(profileImage.FileName);
                filePath = Path.Combine(imageFolderPath,imageFileName);
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    await profileImage.CopyToAsync(stream);
                }
            }
            return filePath;
        }
    }
}