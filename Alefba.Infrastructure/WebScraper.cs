using Alefba.Application.Interfaces;
using HtmlAgilityPack;
using Alefba.Application.Commands;


namespace Alefba.Infrastructure
{
    public class WebScraper : IWebScraper
    {
        public async  Task<CreateExchangeCommand> GetDate()
        {
            var createExchangeCommand = new CreateExchangeCommand();
            var url = "http://mex.co.ir";

            var html = Utility.GetHtml(url);
            var data = Utility.ParseHtmlUsingHtmlAgilityPack(html);

            createExchangeCommand.Rate = Convert.ToInt32(data.rate.Replace(",",String.Empty));
            createExchangeCommand.Symbol = data.symbol;

            return createExchangeCommand;
        }

    }

    
}
