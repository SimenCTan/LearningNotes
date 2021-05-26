namespace DesignPatterns.Decorator
{
    public class Espresso : BeverageBase
    {
        public override string GetDescription()
        {
            return "Espresso";
        }
        public override double Cost()
        {
            return 1.99;
        }
    }
}
