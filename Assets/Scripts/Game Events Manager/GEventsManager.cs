using System;
using System.Collections.Generic;


public static class GEventsManager {
    private static readonly Dictionary<GEvents, Action<GData>> eventsDict;

    static GEventsManager() {
        if (eventsDict == null)
            eventsDict = new Dictionary<GEvents, Action<GData>>();
    }

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

    public static void RemoveListener(GEvents _eventName, Action<GData> _listener) {
        if (eventsDict.TryGetValue(_eventName, out Action<GData> _event)) {
            _event -= _listener;
            eventsDict[_eventName] = _event;
        }
    }

    public static void Invoke(GEvents _eventName, GData data) {
        if (eventsDict.TryGetValue(_eventName, out Action<GData> _event))
            _event.Invoke(data);
    }
}




public class GData : EventArgs {
    private object[] args;

    public GData(params object[] _args) {
        args = _args;
    }

    public T Get<T>(int index) {
        return (T)args[index];
    }
}