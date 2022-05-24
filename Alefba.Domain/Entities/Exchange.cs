namespace Alefba.Domain.Entities
{
    public class Exchange : BaseDomainEntity
    {
        public Exchange(int rate, string symbol)
        {
            Rate = rate;
            DateTime = DateTime.UtcNow;
            Symbol = symbol;
        }

        public int Rate { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
    }

}
