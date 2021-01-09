using UnityEngine;
using UnityEngine.Events;

public class DesignEventListener : MonoBehaviour
{
    public DesignEventData Event;
    public UnityEvent OnEvent;

    // --------------------------------------------------------------------

    private void Awake()
    {
        EventManager<DesignEvent>.StartListening(OnDesignEventCallback);
    }

    // --------------------------------------------------------------------

    private void OnDestroy()
    {
        EventManager<DesignEvent>.StopListening(OnDesignEventCallback);
    }

    // --------------------------------------------------------------------

    private void OnDesignEventCallback(DesignEvent ev)
    {
        if (ev.Data == Event)
            OnEvent.Invoke();
    }
}
