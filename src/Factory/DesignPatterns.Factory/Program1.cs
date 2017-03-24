using DesignPatterns.Factory.Automobile;

namespace DesignPatterns.Factory
{
	public class Program1
	{
		public static void Main1(string[] args)
		{
			string carName = args[0];

			IAuto car = GetCar(carName);
			car.TurnOn();
			car.TurnOff();
		}

		static IAuto GetCar(string carName)
		{
			switch (carName)
			{
				case "bmw":
					return new BMW335Xi();
				case "mini":
					return new MiniCooper();
				case "audi":
					return new AudiTTS();
				default:
					return new NullAuto();
			}
		}
	}
}
