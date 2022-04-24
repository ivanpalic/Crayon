using System.Text.Json.Serialization;

namespace Exchange.Models
{
    public class Root
    {
        public Motd? Motd { get; set; }
        public string? Success { get; set; }
        public string? Base { get; set; }
        public DateTime Date { get; set; }        
        [JsonPropertyName("rates")]
        public List<Rate>? Rates { get; set; }

    }
}
