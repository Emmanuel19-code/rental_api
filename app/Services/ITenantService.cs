using app.Domain.Contract;

namespace app.Services
{
    public interface ITenantService
    {
        Task<ApiResponse<TenantReponse>> CreateTenant (CreateTenant request);
        Task<ApiResponse<TenantReponse>> GetTenant(string cognitoId);
        Task<ApiResponse<TenantReponse>> UpdateTenant (UpdateTenant request,string cognitoId);
        Task<ApiResponse<PropertyResponse>> AddFavoriteProperty(string cognitoId,string propertyId);
        Task<ApiResponse<PropertyResponse>> RemoveFavoriteProperty(string cognitoId,string propertyId);
    }
}