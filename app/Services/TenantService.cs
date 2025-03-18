using System.IdentityModel.Tokens.Jwt;
using app.Domain.Contract;
using app.Domain.Entities;
using app.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

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
            Console.WriteLine($"{request.Name} {request.Email} {request.PhoneNumber}");
            try
            {
                if (request == null)
                {
                    return new ApiResponse<TenantReponse>("Please provide the missing information",false);

                }
                var tenantId = GenerateTenantId();
                var tenant = new Tenants
                {
                    TenantId = tenantId,
                    TenantCognitoId = request.CognitoId,
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };
                // DecodeJwt();
                await _dbContext.Tenants.AddAsync(tenant);
                await _dbContext.SaveChangesAsync();
                var response = new TenantReponse
                {
                    TenantId = tenant.TenantId,
                    TenantCognito = tenant.TenantCognitoId,
                    Name = tenant.Name,
                    Email = tenant.Email,
                    PhoneNumber = tenant.PhoneNumber
                };
                return new ApiResponse<TenantReponse>(response,"created",true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ApiResponse<TenantReponse>(ex.Message,false);
            }
        }

        public async Task<ApiResponse<TenantReponse>> GetTenant(string cognitoId)
        {
            var tenant = await _dbContext.Tenants
                .FirstOrDefaultAsync(t => t.TenantCognitoId == cognitoId);
            if (tenant == null)
            {
                return new ApiResponse<TenantReponse>("No Tenant Found",false);
            }

            var info = new TenantReponse
            {
                TenantId = tenant.TenantId,
                TenantCognito = tenant.TenantCognitoId,
                Name = tenant.Name,
                Email = tenant.Email,
                PhoneNumber = tenant.PhoneNumber,

            };

            return new ApiResponse<TenantReponse>(info,"",true);
        }

        public async Task<ApiResponse<TenantReponse>> UpdateTenant(UpdateTenant request, string cognitoId)
        {
            if (string.IsNullOrEmpty(cognitoId) || request == null)
            {
                return new ApiResponse<TenantReponse>("Provide Id",false);
            }

            var tenant = await _dbContext.Tenants.FirstOrDefaultAsync(t => t.TenantCognitoId == cognitoId);
            if (tenant == null)
            {
                return new ApiResponse<TenantReponse>("Not Found",false);
            }
            tenant.Name = request.Name;
            tenant.Email = request.Email;
            tenant.PhoneNumber = request.PhoneNumber;
            try
            {
                _dbContext.Tenants.Update(tenant);
                await _dbContext.SaveChangesAsync();

                var response = new TenantReponse
                {
                    TenantId = tenant.TenantId,
                    Name = tenant.Name,
                    Email = tenant.Email,
                    PhoneNumber = tenant.PhoneNumber,

                };

                return new ApiResponse<TenantReponse>(response, "Tenant updated successfully",true);
            }
            catch (Exception ex)
            {
                return new ApiResponse<TenantReponse>($"An error occurred: {ex.Message}",false);
            }
        }

        //public string DecodeJwt()
        //{
        //    var authorizationHeader = _httpContext.Request.Headers["Authorization"];
        //    if(StringValues.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.ToString().StartsWith("Bearer "))
        //    {
        //        return "Unauthorized: No valid provided";
        //    }
        //    var token = authorizationHeader.ToString().Split(" ")[1];
        //    var handler = new JwtSecurityTokenHandler();
        //    var jwtToken =  handler.ReadJwtToken(token);
        //    Console.WriteLine(jwtToken);
        //    return jwtToken.ToString();
        //}
        private static void SaveCounterToFile(int counter)
        {
            File.WriteAllText("Tenantcounter.txt", counter.ToString());
        }
        public int GetCounterFromFile()
        {
            if (!File.Exists("Tenantcounter.txt"))
            {
                return 1;
            }
            string counterValue = File.ReadAllText("Tenantcounter.txt");
            return int.TryParse(counterValue, out int counter) ? counter : 1;
        }
        public string GenerateTenantId()
        {
            string yearOfRegistration = DateTime.Now.Year.ToString();
            int counter = GetCounterFromFile();
            string userID = "T" + counter.ToString("D4") + yearOfRegistration;
            SaveCounterToFile(counter + 1);
            return userID;
        }


    }
}