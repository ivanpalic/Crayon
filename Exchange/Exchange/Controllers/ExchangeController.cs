using Exchange.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

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
            webRequest.ContentType = "application/json";

            WebResponse webResponse = await webRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());

            string s = sr.ReadToEnd();

            JObject parsed = JObject.Parse(s);

            var rr = parsed.Last.ToObject<Object>();

            HostResponse rates = JsonConvert.DeserializeObject<HostResponse>(s);

            return new JsonResult(new ExchangeResult
            {
                Max =  new Rate { Currency = "RSD", ExchangeRate = 175.57 },
                Min = new Rate { Currency = "RSD", ExchangeRate = 175.57 },
                Average = 0.12345
            });
        }
    }
}