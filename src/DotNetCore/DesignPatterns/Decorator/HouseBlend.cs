namespace DesignPatterns.Decorator
{
    public class HouseBlend:BeverageBase
    {
        public override string GetDescription()
        {
            return "house blend";
        }
        public override double Cost()
        {
            return 0.89;
        }
    }
}
