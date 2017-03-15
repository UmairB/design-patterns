namespace DesignPatterns.DecoratorDesign
{
    public class MediumPizza : Pizza
    {
        public MediumPizza()
        {
            this.Description = "Medium Pizza";
        }

        public override string GetDescription()
        {
            return Description;
        }

        public override double CalculateCost()
        {
            return 6.00;
        }
    }
}
