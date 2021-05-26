using System;
using DesignPatterns.DuckStrategy;
using DesignPatterns.SubjectObserver;
using DesignPatterns.Decorator;
namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strategy Pattern");
            var modelDuck=new ModelDuck();
            modelDuck.PerformFly();
            modelDuck.PerformQuack();
            modelDuck.SetFlyBehavior(new ModelFly());
            modelDuck.PerformFly();

            Console.WriteLine("Observer Patterns!");
            var weatherData=new WeatherData();
            var observerone=new OberverElement(weatherData);
            observerone.Subscript();
            var observertwo=new OberverOtherElement(weatherData);
            observertwo.Subscript();
            weatherData.SetMeasurementsChanged((float)35.50,(float)20.00,(float)264.00);

            observerone.UnSubscript();
            weatherData.SetMeasurementsChanged((float)37.50,(float)30.00,(float)260.00);

            Console.WriteLine("Decorator Patterns");
            var beverage = new Espresso();
            Console.WriteLine(beverage.GetDescription());

            BeverageBase beverage2=new HouseBlend();
            beverage2=new Mocha(beverage2);
            beverage2=new Whip(beverage2);
            Console.WriteLine(beverage2.GetDescription()+"$"+beverage2.Cost());
        }
    }
}
