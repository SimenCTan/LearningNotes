using System.Collections;
using System;
using System.Linq;

namespace DesignPatterns.SubjectObserver
{
    public class WeatherData:ISubject
    {
        private float _temp;
        private float _humidity;
        private float _pressure;

        private ArrayList observers;

        public WeatherData()
        {
            observers=new ArrayList();
        }

        public void RegisterObserver(IObserverElement observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserverElement observer)
        {
            var observerIndex = observers.IndexOf(observer);
            if(observerIndex>=0)
            {
                observers.RemoveAt(observerIndex);
            }
        }

        public void NotifyObservers()
        {
            foreach(var observer in observers)
            {
                ((IObserverElement)observer).Update(_temp,_humidity,_pressure);
            }
        }

        public void SetMeasurementsChanged(float temp,float humidity,float pressure)
        {
            _temp=temp;
            _humidity=humidity;
            _pressure=pressure;
            NotifyObservers();
        }
    }
}
