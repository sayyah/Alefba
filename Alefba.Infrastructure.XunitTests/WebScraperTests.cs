using Alefba.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Infrastructure.XunitTests
{
    public class WebScraperTests
    {
        private readonly IWebScraper _webScraper;
        public WebScraperTests()
        {
            _webScraper = new WebScraper();
        }

        [Fact]
        public async Task GetData()
        {

            //Act
            var actual =await _webScraper.GetDate();

            //Assert
            Assert.Equal("USD", actual.Symbol);
        }
    }
}
