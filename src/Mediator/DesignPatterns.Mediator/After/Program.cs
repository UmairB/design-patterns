using System;

namespace DesignPatterns.Mediator.After
{
	public class ProgramAfter
	{
		public static void MainAfter(string[] args)
		{
			var airTrafficControl = new YytCenter();

			var flight1 = new Airbus321("AC159", airTrafficControl);
            var flight2 = new Boeing737200("WS203", airTrafficControl);
            var flight3 = new Embraer190("AC602", airTrafficControl);

			flight1.Altitude += 1000;

			Console.ReadKey();
		}
	}
}
