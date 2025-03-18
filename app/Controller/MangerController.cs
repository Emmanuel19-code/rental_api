using app.Domain.Contract;
using app.Services;
using Microsoft.AspNetCore.Mvc;

namespace app.Controller
{
    [Route("/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
      public ManagerController(IManagerService managerService)
      {
        _managerService = managerService;
      }
      [HttpPut("{cognitoId}")]
      public async Task<ActionResult> UpdateManagerProfile(UpdateManager request,string cognitoId)
      {
        var response = await _managerService.UpdateManager(request,cognitoId);
        if(response.IsSuccess)
         {
            return Ok(response);
         }else
         {
            return BadRequest(response);
         }
      }
      [HttpPost("add_manager")]
      public async Task<ActionResult> AddManager(AddManager request)
      {
         var response = await _managerService.AddManager(request);
         if(response.IsSuccess)
         {
            return Ok(response);
         }
         else{
            return BadRequest(response);
         }
      }

      [HttpGet("{cognitoId}")]
      public async Task<ActionResult> ManagerProfile(string cognitoId)
      {
        var response = await _managerService.GetManagerProfile(cognitoId);
        if(response.IsSuccess)
        {
            return Ok(response);
        }else{
            return BadRequest(response);
        }
      }
    }
}