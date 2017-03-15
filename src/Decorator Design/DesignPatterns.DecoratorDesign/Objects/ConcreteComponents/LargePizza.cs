namespace DesignPatterns.DecoratorDesign
{
    public class LargePizza : Pizza
    {
        public LargePizza()
        {
            this.Description = "Large Pizza";
        }

        public override string GetDescription()
        {
            return Description;
        }

        public override double CalculateCost()
        {
            return 9.00;
        }
    }
}
