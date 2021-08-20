using DesignPatterns.Factory.SimpleFactory;

namespace DesignPatterns.Factory
{
    public class SimplePizzaStore
    {
        private readonly SimplePizzaFactory _simplePizzaFactory;
        public SimplePizzaStore(SimplePizzaFactory simplePizzaFactory)
        {
            _simplePizzaFactory=simplePizzaFactory;
        }
        public Pizza OrderPizza(string type)
        {
            var pizza=_simplePizzaFactory.CreatePizza(type);
            return pizza;
        }
    }
}
