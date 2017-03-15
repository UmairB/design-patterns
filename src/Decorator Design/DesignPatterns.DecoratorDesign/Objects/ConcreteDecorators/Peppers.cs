namespace DesignPatterns.DecoratorDesign
{
    public class Peppers : PizzaDecorator
    {
        public Peppers(Pizza pizza) : base(pizza)
        {
            Description = "Peppers";
        }

        public override string GetDescription()
        {
            return string.Format("{0}, {1}", Pizza.GetDescription(), Description);
        }

        public override double CalculateCost()
        {
            return Pizza.CalculateCost() + 2.00;
        }
    }
}
