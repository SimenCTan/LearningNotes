using System;
using DesignPatterns.SubjectObserver;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Observer Patterns!");
            var weatherData=new WeatherData();
            var observerone=new OberverElement(weatherData);
            observerone.Subscript();
            var observertwo=new OberverOtherElement(weatherData);
            observertwo.Subscript();
            weatherData.SetMeasurementsChanged((float)35.50,(float)20.00,(float)264.00);

            observerone.UnSubscript();
            weatherData.SetMeasurementsChanged((float)37.50,(float)30.00,(float)260.00);
        }
    }
}
