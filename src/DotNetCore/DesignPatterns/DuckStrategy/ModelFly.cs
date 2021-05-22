using System;

namespace DesignPatterns.DuckStrategy
{
    public class ModelFly : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine($"Model fly");
        }
    }
}
