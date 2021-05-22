using System;

namespace DesignPatterns.DuckStrategy
{
    public class ModelDuck:Duck
    {
        public ModelDuck()
        {
            Flyable=new FlyNoWay();
            Quackabl=new QuackNoWay();
        }

        public override void Display()
        {
            Console.WriteLine($"Model duck");
        }
    }
}
