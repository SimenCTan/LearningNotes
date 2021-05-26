namespace DesignPatterns.Decorator
{
    public class Mocha:CondimentDecorator
    {
        private BeverageBase _beverage;
        public Mocha(BeverageBase beverage)
        {
            _beverage=beverage;
        }
        public override string GetCondimentDescription()
        {
            return _beverage.GetDescription()+",Mocha";
        }

        public override double Cost()
        {
            return 0.20+_beverage.Cost();
        }
    }
}
