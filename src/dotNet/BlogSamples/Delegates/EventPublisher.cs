public class EventPublisher
{
    public event EventHandler? EventOccurred;

    public void DoSomething()
    {
        // 执行某些操作
        // 触发事件
        OnEventOccurred("Event occurred!");
    }

    protected virtual void OnEventOccurred(string message)
    {
        // 检查是否有订阅者，并调用事件处理程序
        EventOccurred?.Invoke(message);
    }
}
