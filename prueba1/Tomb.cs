using UnityEngine;
using UnityEngine.Events;

public class OnStepOnTombEvent : BaseEvent { }

public class Tomb : MonoBehaviour
{
    public UnityEvent OnPlayerStepOn;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager<OnStepOnTombEvent>.TriggerEvent();
    }
}
