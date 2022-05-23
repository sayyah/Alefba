namespace Alefba.Application.DTOs
{
    public class ExchangeDto : BaseDto
    {
        public int Rate { get; set; }
        public DateTime DateTime { get; set; }
        public string Symbol { get; set; }
    }
}
