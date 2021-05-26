namespace DesignPatterns.Decorator
{
    public class Whip : CondimentDecorator
    {
        public Whip(BeverageBase beverage):base(beverage)
        {
        }
        public override double Cost()
        {
            return 0.50+_beverage.Cost();
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription()+",Whip";
        }
    }
}
