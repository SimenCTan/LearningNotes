namespace DesignPatterns.Decorator
{
    public abstract class BeverageBase
    {
        protected string description="base abstract beverage";
        public string GetDescription()
        {
            return description;
        }

        public abstract double Cost();
    }
}
