using app.Domain.Contract;

namespace app.Services
{
    public interface IPropertyService
    {
        Task<ApiResponse<PropertyResponse>> GetAllProperties(GetPropertyRequest request);
        Task<ApiResponse<PropertyResponse>> GetProperty(string id);
        Task<ApiResponse<PropertyResponse>> CreateProperty(CreatePropertyRequest request);
    }
}