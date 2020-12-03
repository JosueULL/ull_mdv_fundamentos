using UnityEngine;

public class OnRockHitEvent : BaseEvent { }

public class Rock : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager<OnRockHitEvent>.TriggerEvent();
    }
}
