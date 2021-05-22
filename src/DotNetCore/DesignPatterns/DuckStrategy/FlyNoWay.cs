using System;

namespace DesignPatterns.DuckStrategy
{
    public class FlyNoWay : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine($"Can not fly");
        }
    }
}
