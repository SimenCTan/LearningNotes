using System;

namespace DesignPatterns.DuckStrategy
{
    public abstract class Duck
    {
        protected IFlyable Flyable;
        protected IQuackabl Quackabl;

        public Duck()
        {

        }

        public virtual void Display()
        {

        }

        public void PerformFly()
        {
            Flyable.Fly();
        }

        public void SetFlyBehavior(IFlyable flyable)
        {
            Flyable=flyable;
        }

        public void PerformQuack()
        {
            Quackabl.quack();
        }

        public void PerformSwim()
        {
            Console.WriteLine($"all duck can swim");
        }
    }
}
