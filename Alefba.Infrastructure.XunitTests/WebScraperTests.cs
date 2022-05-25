using Alefba.Application.Interfaces;
using Shouldly;

namespace Alefba.Infrastructure.XunitTests
{
    public class WebScraperTests
    {
        private readonly IWebScraper _webScraper;
        public WebScraperTests()
        {   
            //arrange
            _webScraper = new WebScraper();
        }

        [Fact]
        public async Task GetData()
        {
            //arrange
            var expect = "USD";

            //Act
            var actual =await _webScraper.GetDate("http://mex.co.ir");

            //Assert
            actual.Symbol.ShouldBe(expect);
        }
    }
}
