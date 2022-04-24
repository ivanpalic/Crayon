using Exchange.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Exchange.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly ILogger<ExchangeController> _logger;

        public ExchangeController(ILogger<ExchangeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]        
        public  async Task<ActionResult<ExchangeResult>> Calculate(ExchangeRequest request)
        {

            String url_str = "https://api.exchangerate.host/latest";

            WebRequest webRequest = WebRequest.Create(url_str);

            WebResponse webResponse = await webRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());

            return new JsonResult(new ExchangeResult
            {
                Max =  new Rate { Date = new DateTime (2022, 4, 23), ExchangeRate = 175.57 },
                Min = new Rate { Date = new DateTime (2022, 4, 23), ExchangeRate = 175.57 },
                Average = 0.12345
            });
        }
    }
}