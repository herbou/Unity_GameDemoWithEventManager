using System;
using System.Collections.Generic;


public static class GEventsManager {
    private static readonly Dictionary<GEvents, Action<GData>> eventsDict;

    static GEventsManager() {
        if (eventsDict == null)
            eventsDict = new Dictionary<GEvents, Action<GData>>();
    }

    /// <summary>
    /// Add a listener to a given event.
    /// </summary>
    /// <param name="eventName">Event name of type (GEvents).</param>
    /// <param name="listener">Event callback that is invoked after an event occurs.</param>
    public static void AddListener(GEvents _eventName, Action<GData> _listener) {
        if (eventsDict.TryGetValue(_eventName, out Action <GData> _event)) {
            _event += _listener;
            eventsDict[_eventName] = _event;
        }
        else {
            _event += _listener;
            eventsDict.Add(_eventName, _event);
        }
    }

    /// <summary>
    /// Remove a listener of a given event.
    /// </summary>
    /// <param name="eventName">Event name of type (GEvents).</param>
    /// <param name="listener">Event callback that is invoked after an event occurs.</param>
    public static void RemoveListener(GEvents _eventName, Action<GData> _listener) {
        if (eventsDict.TryGetValue(_eventName, out Action<GData> _event)) {
            _event -= _listener;
            eventsDict[_eventName] = _event;
        }
    }

    /// <summary>
    /// Trigger an event without data.
    /// </summary>
    /// <param name="eventName">Event name of type (GEvents).</param>
    public static void Invoke(GEvents _eventName) {
        Invoke(_eventName, null);
    }

    /// <summary>
    /// Trigger an event with data.
    /// </summary>
    /// <param name="eventName">Event name of type (GEvents).</param>
    /// <param name="data">Data that you want to pass to listeners.</param>
    public static void Invoke(GEvents _eventName, GData data) {
        if (eventsDict.TryGetValue(_eventName, out Action<GData> _event))
            _event.Invoke(data);
    }
}






public class GData : EventArgs {
    private readonly object[] args;

    /// <summary>
    /// Creates an object to hold data that you want to pass to listeners.
    /// </summary>
    public GData(params object[] _args) {
        args = _args;
    }

    /// <summary>
    /// Gets the data at a given index.
    /// </summary>
    /// <param name="index">The index of the data in the argument's list.</param>
    /// <returns>Returns data with a given type and index.</returns>
    public T Get<T>(int index) {
        return (T)args[index];
    }
}
