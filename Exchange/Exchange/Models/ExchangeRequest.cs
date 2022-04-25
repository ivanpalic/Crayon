namespace Exchange.Models
{
    public class ExchangeRequest
    {
        public List<String>? Dates { get; set; }
        public string? BaseCurrency { get; set; }  
        public string? TargetCurrency { get; set; }
    }
}
