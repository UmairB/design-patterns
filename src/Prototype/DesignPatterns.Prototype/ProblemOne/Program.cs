namespace DesignPatterns.Prototype.ProblemOne
{
	public class Program
	{
		public static void MainOne(string[] args)
		{
			var scraper = new WebPageScraper("http://www.google.com");
			scraper.PrintPageData();

			var scraper2 = scraper.Clone();
			scraper2.PrintPageData();
		}
	}
}
