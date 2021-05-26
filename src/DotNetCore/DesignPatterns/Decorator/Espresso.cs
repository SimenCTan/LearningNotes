namespace DesignPatterns.Decorator
{
    public class Espresso : BeverageBase
    {
        public Espresso()
        {
            description="Espresso";
        }
        public override double Cost()
        {
            return 1.99;
        }
    }
}
