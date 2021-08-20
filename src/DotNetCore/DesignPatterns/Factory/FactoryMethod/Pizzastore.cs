namespace DesignPatterns.Factory.FactoryMethod
{
    public abstract class Pizzastore
    {
        public Pizza OrderPizza(string type)
        {
            var pizza=CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        protected abstract Pizza CreatePizza(string type);
    }
}
