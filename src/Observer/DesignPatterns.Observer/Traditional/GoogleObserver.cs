using System;

namespace DesignPatterns.Observer.Traditional
{
	public class GoogleObserver : AbstractObserver
	{
		private StockTicker DataSource { get; set; }
		
		public GoogleObserver(StockTicker subj)
		{
			this.DataSource = subj;
			subj.Register(this);
		}

		public override void Update()
		{
			decimal price = DataSource.Stock.Price;
			string symbol = DataSource.Stock.Symbol;

			// Reactive Filters
			if (symbol == "GOOG")
				Console.WriteLine("Google's new price is: {0}", price);
		}
	}
}
