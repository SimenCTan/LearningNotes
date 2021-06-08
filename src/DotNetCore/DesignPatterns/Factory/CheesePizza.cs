using System;
namespace DesignPatterns.Factory
{
    public class CheesePizza:Pizza
    {
        public  void Prepare()
        {
            Console.Write("Cheesse pizza prepare");
        }
        public  void Bake()
        {
            Console.Write("Cheesse pizza bake");
        }
        public  void Cut()
        {
            Console.Write("Cheesse pizza cut");
        }
        public  void Box()
        {
            Console.Write("Cheesse pizza box");
        }
    }
}
