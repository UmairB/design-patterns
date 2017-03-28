using System;
using System.Net.Http;

namespace DesignPatterns.Prototype.ProblemOne
{
    public class WebPageScraper
    {
        private string title;
        private int headerTagCount;
        private string firstHeaderTagContents;
        
        public WebPageScraper(string url)
        {
            using(var client = new HttpClient())
            {
                var content = client.GetStringAsync(url).Result;
                Scrape(content);
            }
        }

        private void Scrape(string page)
        {
            title = "Fake title";
            headerTagCount = 3;
            firstHeaderTagContents = "Fake header text";
        }

        public void PrintPageData()
        {
            Console.WriteLine("Title: {0}, Header Count: {1}, First Header: {2}", title, headerTagCount, firstHeaderTagContents);
        }

        public WebPageScraper Clone()
        {
            return (WebPageScraper)MemberwiseClone();
        }
    }
}
