using Exchange.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Exchange
{
    public class Processor
    {
        private HttpClient _httpClient;

        public Processor()
        { 
            _httpClient = new HttpClient();
        }

        public async Task<Rate> GetRate(String date, String baseCurrency, String symbols)
        {
            var response = await _httpClient.GetAsync("https://api.exchangerate.host/" + date + "?base=" + baseCurrency + "&symbols=" + symbols);

            StreamReader sr = new StreamReader(response.Content.ReadAsStream());
            string s = sr.ReadToEnd();

            var list = JToken.Parse(s).Last.Values().ToList();

            double r = 0;

            foreach (JProperty p in list)
            {
                r = Double.Parse(p.Value.ToString());
            }

            Rate res = new Rate()
            {
                Date = date,
                ExchangeRate = r
            };

            return res;

        }
    }
}
