namespace DesignPatterns.Decorator
{
    public class Mocha:CondimentDecorator
    {
        public Mocha(BeverageBase beverage):base(beverage)
        {
        }
        public override string GetDescription()
        {
            return _beverage.GetDescription()+",Mocha";
        }

        public override double Cost()
        {
            return 0.20+_beverage.Cost();
        }
    }
}
