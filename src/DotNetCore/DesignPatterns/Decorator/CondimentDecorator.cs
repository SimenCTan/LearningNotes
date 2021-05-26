namespace DesignPatterns.Decorator
{
    public abstract class CondimentDecorator:BeverageBase
    {
        protected readonly BeverageBase _beverage;
        public CondimentDecorator(BeverageBase beverage)
        {
            _beverage=beverage;
        }
    }
}
