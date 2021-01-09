using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class BaseEvent { }

public class EventManager<T> : MonoBehaviour where T : BaseEvent, new()
{
    private static T defaultInstance = new T();
    private static List<UnityAction<T>> callbacks = new List<UnityAction<T>>();

    // --------------------------------------------------------------------

    public static void StartListening(UnityAction<T> listener)
    {
        if (!callbacks.Contains(listener))
        {
            callbacks.Add(listener);
        }
    }

    // --------------------------------------------------------------------

    public static void StopListening(UnityAction<T> listener)
    {
        callbacks.Remove(listener);
    }

    // --------------------------------------------------------------------

    public static void TriggerEvent(T ev)
    {
        foreach (UnityAction<T> action in callbacks)
            action.Invoke(ev);
    }

    // --------------------------------------------------------------------

    public static void TriggerEvent()
    {
        foreach (UnityAction<T> action in callbacks)
            action.Invoke(defaultInstance);
    }

}