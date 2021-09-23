using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConfigSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _config;
        public ValuesController(IConfiguration config)
        {
            _config = config;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var source = _config.GetValue<string>("DefaultSettings:source");
            var source2 = _config.GetValue<string>("DefaultSettings:source2");
            return new [] { source, source2 };
        }
    }
}