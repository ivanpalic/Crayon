using Exchange.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<ExchangeResult>> Calculate(ExchangeRequest request)
        {
            String baseCurrency = request.BaseCurrency;
            String targetCurrency = request.TargetCurrency;

            Processor processor = new Processor();

            var tasks = request.Dates.Select(date => processor.GetRate(date, baseCurrency, targetCurrency));
            var rates = await Task.WhenAll(tasks);

            Rate max = rates.MaxBy(rate => rate.ExchangeRate);
            Rate min = rates.MinBy(rate => rate.ExchangeRate);
            double avg = rates.Average(rate => rate.ExchangeRate);

            return new JsonResult(new ExchangeResult
            {
                Max = max,
                Min = min,
                Average = avg
            });
        }
    }
}