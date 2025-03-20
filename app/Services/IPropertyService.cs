using app.Domain.Contract;

namespace app.Services
{
    public interface IPropertyService
    {
        Task<ApiResponse<Property>> GetAllProperties(GetPropertyRequest request);
        Task<ApiResponse<Property>> GetProperty(string id);
        Task<ApiResponse<Property>> CreateProperty(CreatePropertyRequest request);
    }
}