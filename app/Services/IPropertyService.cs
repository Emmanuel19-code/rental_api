using app.Domain.Contract;

namespace app.Services
{
    public interface IPropertyService
    {
        Task<ApiResponse<Property>> GetProperty(GetPropertyRequest request);
    }
}