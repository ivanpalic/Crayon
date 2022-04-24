namespace Exchange.Models
{
    public class HostResponse
    {
        public Motd? Motd { get; set; }
        public string? Success { get; set; }
        public string? Base { get; set; }
        public DateTime Date { get; set; }
        public Rate[] Rates { get; set; }

    }
}
