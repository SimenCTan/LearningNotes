namespace DesignPatterns.Factory
{
    public abstract class Pizza
    {
        public abstract Prepare();
        public abstract Bake();
        public abstract Cut();
        public abstract Box();
    }
}
