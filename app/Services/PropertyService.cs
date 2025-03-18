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
        public async Task<ApiResponse<Property>> GetProperty(GetPropertyRequest request)
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
        }
    }
}