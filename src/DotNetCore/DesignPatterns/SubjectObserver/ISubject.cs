namespace DesignPatterns.SubjectObserver
{
    public interface ISubject
    {
        void RegisterObserver(IObserverElement observer);
        void RemoveObserver(IObserverElement observer);
        void NotifyObservers();
    }
}
