using app.Domain.Contract;
using app.Domain.Entities;
using app.Infrastructure;

namespace app.Services
{
    public class TenantService : ITenantService
    {
        private readonly ApplicationDbContext _dbContext;
        public TenantService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse<TenantReponse>> CreateTenant(CreateTenant request)
        {
            try
            {
                if (request == null)
                {
                    return new ApiResponse<TenantReponse>("Please provide the missing information");

                }
                var tenant = new Tenants
                {
                    TenantId = "",
                    TenantCognito = "",
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };
                await _dbContext.Tenants.AddAsync(tenant);
                await _dbContext.SaveChangesAsync();
                var response = new TenantReponse
                {
                    TenantId = tenant.TenantId,
                    TenantCognito = tenant.TenantCognito,
                    Name = tenant.Name,
                    Email = tenant.Email,
                    PhoneNumber = tenant.PhoneNumber
                };
                return new ApiResponse<TenantReponse>(response);
            }
            catch (Exception ex)
            {
            Console.WriteLine(ex);
             return new ApiResponse<TenantReponse>(ex.Message);
            }
        }
    }
}