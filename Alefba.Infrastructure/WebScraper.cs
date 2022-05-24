using Alefba.Application.Interfaces;
using HtmlAgilityPack;
using Alefba.Application.Commands;
using OpenQA.Selenium;
using Alefba.Domain.Entities;

namespace Alefba.Infrastructure
{
    public class WebScraper : IWebScraper
    {
        private IWebDriver _driver { get; set; }
        public WebScraper()
        {
            _driver = Utility.LoadBrowser();
        }
        public async  Task<CreateExchangeCommand> GetDate()
        {
            var url = "http://mex.co.ir";

            var html = _driver.GetHtml(url);
            var data = Utility.ParseHtmlUsingHtmlAgilityPack(html);

            var createExchangeCommand = new CreateExchangeCommand(Convert.ToInt32(data.rate.Replace(",", String.Empty)),data.symbol);

            return createExchangeCommand;
        }

    }

    
}
