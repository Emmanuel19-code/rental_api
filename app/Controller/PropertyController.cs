using app.Domain.Contract;
using app.Services;
using Microsoft.AspNetCore.Mvc;

namespace app.Controller
{
    [Route("/properties")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        [HttpGet]
        public async Task<ActionResult> GetProperties([FromQuery] GetPropertyRequest request)
        {
            Console.WriteLine("called");
            var response =await _propertyService.GetAllProperties(request);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProperty(string id)
        {
            return Ok("property");
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddProperty(CreatePropertyRequest request)
        {
            var response =await _propertyService.CreateProperty(request);
            return Ok(response);
        }
    }
}