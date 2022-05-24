using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using OpenQA.Selenium.Chrome;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Alefba.Infrastructure
{
    public static class Utility
    {
        public static string GetHtml(string url)
        {
            //var options = new ChromeOptions
            //{
            //    BinaryLocation = @"C:\Program Files\Google\Chrome\Application"
            //};
            var options = new ChromeOptions();
            options.AddArguments("headless");
            IWebDriver driver = new ChromeDriver(@"C:\Program Files\Google\Chrome\Application", options);
            //var chrome = new ChromeDriver(options);
            driver.Navigate().GoToUrl(url);

            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));

            wait.Until(driver1 => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));

            return driver.PageSource;
        }

        public static (string symbol, string rate) ParseHtmlUsingHtmlAgilityPack(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var repositories =
                htmlDoc
                    .DocumentNode
                    .SelectSingleNode("/html[1]/body[1]/div[1]/main[1]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/table[1]/tbody[1]/tr[2]/td[4]/span[1]");

            //List<(string RepositoryName, string Description)> data = new();

            //foreach (var repo in repositories)
            //{
            //    var names = repo.SelectNodes("//td/span").ToList();
            //    if(names.Any(x=>x.InnerText.Equals("USD")))
            //    {
            //        var amount = names[2].SelectNodes("//span").FirstOrDefault();
            //        data.Add(("USD", amount.ToString()));
            //    }
            //}

            return ("USD", repositories.InnerText.ToString());
        }
    }
}
