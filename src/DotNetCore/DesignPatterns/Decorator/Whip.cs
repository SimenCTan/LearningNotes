namespace DesignPatterns.Decorator
{
    public class Whip : CondimentDecorator
    {
        private BeverageBase _beverage;
        public Whip(BeverageBase beverage)
        {
            _beverage=beverage;
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
