using System;

namespace DesignPatterns.SubjectObserver
{
    public class OberverElement:IObserverElement,IDisplayElement
    {
        private float _temp;
        private float _humidity;
        private float _pressure;
        private readonly ISubject _subject;
        public OberverElement(ISubject subject)
        {
            _subject=subject;
        }

        public void Subscript()
        {
            _subject.RegisterObserver(this);
        }

        public void UnSubscript()
        {
            _subject.RemoveObserver(this);
        }

        public void Update(float temp,float humidity,float pressure)
        {
            _temp=temp;
            _humidity=humidity;
            _pressure=pressure;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"current temp {_temp},current humidity {_humidity}");
        }
    }
}
