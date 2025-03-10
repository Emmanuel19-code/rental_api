using app.Domain.Contract;
using app.Services;
using Microsoft.AspNetCore.Mvc;

namespace app.Controller
{
    [Route("/api/tenants")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpPost("add_tenant")]
        public async Task<ActionResult> AddTenant(CreateTenant request)
        {
            var response = await _tenantService.CreateTenant(request);
            if(response.IsSuccess)
            {
                return Ok(response);
            }
            else{
                return BadRequest(response);
            }
        }

        [HttpPost("{cognitoId}")]
        public async Task<ActionResult> TenantInfo (string cognitoId)
        {
            Console.WriteLine("hello");
            var response = await _tenantService.GetTenant(cognitoId);
            if(response.IsSuccess)
            {
                return Ok(response);
            }
            else{
                return BadRequest(response);
            }
        }
    }
}