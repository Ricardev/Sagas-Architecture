using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;

namespace EurekaService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EurekaController : ControllerBase
    {

        private readonly ILogger<EurekaController> _logger;
        private readonly DiscoveryHttpClientHandler _handler;
        public EurekaController(ILogger<EurekaController> logger, IDiscoveryClient client)
        {
            _logger = logger;
            _handler = new DiscoveryHttpClientHandler(client);
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var client = new HttpClient(_handler, false);
            return await client.GetStringAsync("http://ProductService/api/weatherforecast");
        }
    }
}
