using app.Domain.Contract;
using app.Services;
using Microsoft.AspNetCore.Mvc;

namespace app.Controller
{
    [Route("/tenants")]
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
            Console.WriteLine("adding tenant",request);
            var response = await _tenantService.CreateTenant(request);
            if(response.IsSuccess)
            {
                return Ok(response);
            }
            else{
                return BadRequest(response);
            }
        }

        [HttpGet("{cognitoId}")]
        public async Task<ActionResult> TenantInfo (string cognitoId)
        {
            var response = await _tenantService.GetTenant(cognitoId);
            if(response.IsSuccess)
            {
                return Ok(response);
            }
            else{
                return BadRequest(response);
            }
        }

        [HttpPut("{cognitoId}")]
        public async Task<ActionResult> UpdateTenantInfo (string cognitoId,UpdateTenant request)
        {
           var response = await _tenantService.UpdateTenant(request,cognitoId);
           if(response.IsSuccess)
           {
             return Ok(response);
           }else
           {
             return BadRequest(response);
           }
        
        }
    }
}