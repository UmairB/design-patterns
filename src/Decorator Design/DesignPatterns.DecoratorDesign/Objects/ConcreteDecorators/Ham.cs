namespace DesignPatterns.DecoratorDesign
{
    public class Ham : PizzaDecorator
    {
        public Ham(Pizza pizza) : base(pizza)
        {
            Description = "Ham";
        }

        public override string GetDescription()
        {
            return string.Format("{0}, {1}", Pizza.GetDescription(), Description);
        }

        public override double CalculateCost()
        {
            return Pizza.CalculateCost() + 1.00;
        }
    }
}
