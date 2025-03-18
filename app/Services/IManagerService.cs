using app.Domain.Contract;

namespace app.Services
{
    public interface IManagerService
    {
        Task<ApiResponse<ManagerReponse>> UpdateManager(UpdateManager request,string cognitoId);
        Task<ApiResponse<ManagerReponse>> AddManager(AddManager request);
        Task<ApiResponse<ManagerReponse>> GetManagerProfile(string cognitoId);
    }
}