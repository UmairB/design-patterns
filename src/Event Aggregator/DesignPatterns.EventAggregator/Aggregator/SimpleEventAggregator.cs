using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Threading;
using DesignPatterns.EventAggregator.Event;

namespace DesignPatterns.EventAggregator.Aggregator
{
    public class SimpleEventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, List<WeakReference>> _eventSubscribersLists = 
            new Dictionary<Type, List<WeakReference>>();
        private readonly object _lock = new object();

        public void Subscribe(object subscriber)
        {
            lock (_lock)
            {
                var subscriberTypes = 
                    subscriber.GetType().GetTypeInfo().GetInterfaces()
                        .Where(i => i.IsConstructedGenericType && i.GetGenericTypeDefinition() == typeof(ISubscriber<>));

                if (subscriberTypes.Any())
                {
                    var weakReference = new WeakReference(subscriber);
                    foreach (var subscriberType in subscriberTypes)
                    {
                        var subscribers = GetSubscribers(subscriberType);
                        subscribers.Add(weakReference);
                    }
                }
            }
        }

        public void Publish<TEvent>(TEvent eventToPublish)
        {
            var subscriberType = typeof(ISubscriber<>).MakeGenericType(typeof(TEvent));
            var subscribers = GetSubscribers(subscriberType);
            List<WeakReference> subscribersToRemove = new List<WeakReference>();

            foreach (var weakSubscriber in subscribers)
            {
                if (weakSubscriber.IsAlive)
                {
                    var subscriber = (ISubscriber<TEvent>)weakSubscriber.Target;
                    var syncContext = SynchronizationContext.Current;
                    if (syncContext == null)
                        syncContext = new SynchronizationContext();

                    syncContext.Post(s => subscriber.OnEvent(eventToPublish), null);
                }
                else
                {
                    subscribersToRemove.Add(weakSubscriber);
                }
            }

            if (subscribersToRemove.Count > 0)
            {
                lock(_lock)
                {
                    foreach (var remove in subscribersToRemove)
                        subscribers.Remove(remove);
                }
            }
        }

        private List<WeakReference> GetSubscribers(Type subscriberType)
        {
            List<WeakReference> subscribers;
            lock (_lock)
            {
                var found = _eventSubscribersLists.TryGetValue(subscriberType, out subscribers);
                if (!found)
                {
                    subscribers = new List<WeakReference>();
                    _eventSubscribersLists.Add(subscriberType, subscribers);
                }
            }

            return subscribers;
        }
    }
}
