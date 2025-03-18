using app.Domain.Contract;
using Microsoft.AspNetCore.Mvc;

namespace app.Controller
{
    [Route("/property")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        public async Task<ActionResult> GetProperty([FromQuery] GetPropertyRequest request)
        {
            return Ok("cool");
        }
    }
}