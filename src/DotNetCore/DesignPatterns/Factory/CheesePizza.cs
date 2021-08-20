using System;
namespace DesignPatterns.Factory
{
    public class CheesePizza:Pizza
    {
        public override void Prepare()
        {
            Console.Write("Cheesse pizza prepare");
        }
        public override void Bake()
        {
            Console.Write("Cheesse pizza bake");
        }
        public override void Cut()
        {
            Console.Write("Cheesse pizza cut");
        }
        public override void Box()
        {
            Console.Write("Cheesse pizza box");
        }
    }
}
