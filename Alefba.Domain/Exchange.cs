namespace Alefba.Domain
{
    public class Exchange : BaseDomainEntity
    {
        public int Rate { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
    }
}
