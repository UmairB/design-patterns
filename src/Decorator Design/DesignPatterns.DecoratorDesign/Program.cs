using System;

namespace DesignPatterns.DecoratorDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            var largePizza = new LargePizza();

            Console.WriteLine(largePizza.Description);
            Console.WriteLine("{0:C2}", largePizza.CalculateCost());

            // decorator
            Pizza largePizzaDec = new LargePizza();
            largePizzaDec = new Cheese(largePizzaDec);
            largePizzaDec = new Ham(largePizzaDec);
            largePizzaDec = new Peppers(largePizzaDec);

            Console.WriteLine(largePizzaDec.GetDescription());
            Console.WriteLine("{0:C2}", largePizzaDec.CalculateCost());

            Console.ReadKey();
        }
    }
}
