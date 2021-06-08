using DesignPatterns.Factory.SimpleFactory;

namespace DesignPatterns.Factory
{
    public class PizzaStore
    {
        private readonly SimplePizzaFactory _simplePizzaFactory;
        public PizzaStore(SimplePizzaFactory simplePizzaFactory)
        {
            _simplePizzaFactory=simplePizzaFactory;
        }
        public Pizza OrderPizza(string type)
        {
            var pizza=_simplePizzaFactory.CreatePizza(type);

        }
    }
}
