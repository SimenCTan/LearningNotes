namespace DesignPatterns.Decorator
{
    public class HouseBlend:BeverageBase
    {
        public HouseBlend()
        {
            description="house blend";
        }

        public override double Cost()
        {
            return 0.89;
        }
    }
}
