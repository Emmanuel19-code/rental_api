using app.Domain.Contract;
using app.Domain.Entities;
using app.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace app.Services
{
    public class ManagerService : IManagerService
    {
        private readonly ApplicationDbContext _dbContext;
        public ManagerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponse<ManagerReponse>> AddManager(AddManager request)
        {
            if(request == null)
            {
                 return new ApiResponse<ManagerReponse>("Please provide the details",false);
            }
            var managerExist = await _dbContext.Managers.FirstOrDefaultAsync(m=>m.ManagerCognitoId == request.CognitoId);
            if(managerExist != null)
            {
                return new ApiResponse<ManagerReponse>("Manager Already Registered",false);
            }
            var managerId = GenerateId();
            var manager = new Manager
            {
                ManagerId = managerId,
                ManagerCognitoId = request.CognitoId,
                ManagerName = request.Name,
                ManagerEmail = request.Email,   
                ManagerPhone = request.PhoneNumber,
            };
            await _dbContext.Managers.AddAsync(manager);
            await _dbContext.SaveChangesAsync();
            var info = new ManagerReponse
             {
                ManagerId = manager.ManagerId,
                ManagerCognitoId = manager.ManagerCognitoId,
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPhone = manager.ManagerPhone,
             };
            return new ApiResponse<ManagerReponse>(info,"Manager Added ",true);
        }
        public async Task<ApiResponse<ManagerReponse>> GetManagerProfile(string cognitoId)
        {
            if(string.IsNullOrEmpty(cognitoId))
            {
                return new ApiResponse<ManagerReponse>("Inavlid Input",false);
            }
            var manager = await _dbContext.Managers.FirstOrDefaultAsync(m=>m.ManagerCognitoId == cognitoId);
            if(manager == null)
            {
                return new ApiResponse<ManagerReponse>("Not found",false);
            }
            var info = new ManagerReponse
             {
                ManagerId = manager.ManagerId,
                ManagerCognitoId = manager.ManagerCognitoId,
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPhone = manager.ManagerPhone,
             };
             return new ApiResponse<ManagerReponse>(info,"",true);
        }
        public async Task<ApiResponse<ManagerReponse>> UpdateManager(UpdateManager request, string cognitoId)
        {
            if (string.IsNullOrEmpty(cognitoId) || request == null)
            {
                return new ApiResponse<ManagerReponse>("Provide Id",false);
            }
            var manager = await _dbContext.Managers.FirstOrDefaultAsync(m => m.ManagerCognitoId == cognitoId);
            if (manager == null)
            {
                return new ApiResponse<ManagerReponse>("No matching Results",false);
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                manager.ManagerEmail = request.Email;
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                manager.ManagerName = request.Name;
            }
            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                manager.ManagerPhone = request.PhoneNumber;
            }
            try
            {
                _dbContext.Managers.Update(manager);
                await _dbContext.SaveChangesAsync();
                var response = new ManagerReponse
                {
                    ManagerId = manager.ManagerId,
                    ManagerCognitoId = manager.ManagerCognitoId,
                    ManagerName = manager.ManagerName,
                    ManagerPhone = manager.ManagerPhone,
                    ManagerEmail = manager.ManagerEmail,
                };
                return new ApiResponse<ManagerReponse>(response, "Profile Updated",true);
            }
            catch (Exception ex)
            {

                return new ApiResponse<ManagerReponse>($"error: {ex.Message}",false);
            }
        }

        private static void SaveCounterToFile(int counter)
        {
            File.WriteAllText("Managercounter.txt", counter.ToString());
        }
        public int GetCounterFromFile()
        {
            if (!File.Exists("Managercounter.txt"))
            {
                return 1;
            }
            string counterValue = File.ReadAllText("Managercounter.txt");
            return int.TryParse(counterValue, out int counter) ? counter : 1;
        }
        public string GenerateId()
        {
            string yearOfRegistration = DateTime.Now.Year.ToString();
            int counter = GetCounterFromFile();
            string userID = "M" + counter.ToString("D4") + yearOfRegistration;
            SaveCounterToFile(counter + 1);
            return userID;
        }

        
    }
}