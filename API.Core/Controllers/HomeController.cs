using Microsoft.AspNetCore.Mvc;

namespace API.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(System.Runtime.InteropServices.RuntimeInformation.OSDescription);
        }
    }
}