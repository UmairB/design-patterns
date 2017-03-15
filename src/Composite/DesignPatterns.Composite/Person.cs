using System;

namespace DesignPatterns.Composite
{
    public class Person : IParty
    {
        public string Name { get; set; }

        public int Gold { get; set; }

        public void Stats()
        {
            Console.WriteLine("{0} has {1} gold coins", Name, Gold);
        }
    }
}
