namespace DesignPatterns.Factory.SimpleFactory
{
    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza pizza=default;
            if(type.Equals("Cheese"))
            {
                pizza=new CheesePizza();
            }
            return pizza;
        }
    }
}
