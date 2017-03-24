using DesignPatterns.Factory.Automobile;

namespace DesignPatterns.Factory.Factories
{
	public class AutoFactory
	{
        public IAuto CreateInstance(string carName)
		{
			// use reflection to grab instance of IAuto from carName string

			return new NullAuto();
		}
	}
}
