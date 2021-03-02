using Microsoft.AspNetCore.Mvc;

namespace Tournament40.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello Malte";
        }
    }
}
