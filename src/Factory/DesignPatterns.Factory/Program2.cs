using DesignPatterns.Factory.Automobile;
using DesignPatterns.Factory.Factories;

namespace DesignPatterns.Factory
{
	public class Program2
	{
		public static void Main2(string[] args)
		{
			string carName = args[0];

            AutoFactory factory = new AutoFactory();

			IAuto car = factory.CreateInstance(carName);

			car.TurnOn();
			car.TurnOff();
		}
	}
}
