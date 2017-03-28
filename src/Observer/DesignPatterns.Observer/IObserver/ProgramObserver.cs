namespace DesignPatterns.Observer.IObserver
{
	public class ProgramObserver
	{
		public static void MainObserver(string[] args)
		{
			// Monitor a stock ticker, when particular events occur, react
			StockTicker st = new StockTicker();

			GoogleMonitor gf = new GoogleMonitor();
			MicrosoftMonitor mf = new MicrosoftMonitor();

			using (st.Subscribe(gf))
			using (st.Subscribe(mf))
			{
				// Load the Sample Stock Data
				foreach (var s in SampleData.getNext())
					st.Stock = s;
			}
		}
	}
}
