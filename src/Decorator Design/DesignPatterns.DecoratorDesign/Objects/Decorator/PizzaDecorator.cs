namespace DesignPatterns.DecoratorDesign
{
    public abstract class PizzaDecorator : Pizza
    {
        protected Pizza Pizza { get; set; }

        public PizzaDecorator(Pizza pizza)
        {
            Pizza = pizza;
        }

        public override string GetDescription()
        {
            return Pizza.Description;
        }

        public override double CalculateCost()
        {
            return Pizza.CalculateCost();
        }
    }
}
