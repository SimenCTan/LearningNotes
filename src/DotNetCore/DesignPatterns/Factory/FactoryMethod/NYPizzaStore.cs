namespace DesignPatterns.Factory.FactoryMethod
{
    public class NYPizzaStore:Pizzastore
    {
        protected override Pizza CreatePizza(string type)
        {
            if(type.Equals("cheese"))
            {
                return new CheesePizza();
            }
            else return null;
        }
    }
}
