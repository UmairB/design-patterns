namespace DesignPatterns.EventAggregator.Event
{
    public interface ISubscriber<T>
    {
        void OnEvent(T e);
    }
}
