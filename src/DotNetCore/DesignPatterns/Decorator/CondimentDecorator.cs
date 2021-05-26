namespace DesignPatterns.Decorator
{
    public abstract class CondimentDecorator:BeverageBase
    {
        public abstract string GetCondimentDescription();
    }
}
