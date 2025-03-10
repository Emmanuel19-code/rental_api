using app.Domain.Contract;

namespace app.Services
{
    public interface ITenantService
    {
        Task<ApiResponse<TenantReponse>> CreateTenant (CreateTenant request);
        Task<ApiResponse<TenantReponse>> GetTenant(string cognitoId);
    }
}