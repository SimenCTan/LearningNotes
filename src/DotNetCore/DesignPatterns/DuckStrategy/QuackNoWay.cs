using System;

namespace DesignPatterns.DuckStrategy
{
    public class QuackNoWay : IQuackabl
    {
        public void quack()
        {
            Console.WriteLine($"quack no way");
        }
    }
}
