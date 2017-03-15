namespace DesignPatterns.DecoratorDesign
{
    public class SmallPizza : Pizza
    {
        public SmallPizza()
        {
            this.Description = "Small Pizza";
        }

        public override string GetDescription()
        {
            return Description;
        }

        public override double CalculateCost()
        {
            return 3.00;
        }
    }
}
