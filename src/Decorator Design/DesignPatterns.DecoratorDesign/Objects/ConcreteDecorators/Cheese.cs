namespace DesignPatterns.DecoratorDesign
{
    public class Cheese : PizzaDecorator
    {
        public Cheese(Pizza pizza) : base(pizza)
        {
            Description = "Cheese";
        }

        public override string GetDescription()
        {
            return string.Format("{0}, {1}", Pizza.GetDescription(), Description);
        }

        public override double CalculateCost()
        {
            return Pizza.CalculateCost() + 1.25;
        }
    }
}
