using System;
using System.Collections.Generic;

public enum EventType
{
    
}

public class EventManager : Manager
{
    private readonly Dictionary<EventType, Action> eventDictionary = new();

    public void AddListener(EventType eventType, Action action)
    {
        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary.Add(eventType, null);
        }

        eventDictionary[eventType] -= action;
        eventDictionary[eventType] += action;
    }

    public void RemoveListener(EventType eventType, Action action) 
    { 
        if (eventDictionary.ContainsKey(eventType) && eventDictionary[eventType] != null) 
        {
            eventDictionary[eventType] -= action;
        }
    }

    public void InvokeEvent(EventType eventType)
    {
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType]?.Invoke();
        }
    }
}
