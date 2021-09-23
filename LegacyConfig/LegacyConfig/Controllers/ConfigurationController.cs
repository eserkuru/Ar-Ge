using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LegacyConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ConfigurationController(IConfiguration config)
        {
            _config = config;
        }
        public IActionResult Get()
        {
            var config = _config.Get<AppConfig>();

            return new JsonResult(config);
        }
    }
}