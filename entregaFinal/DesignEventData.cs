using UnityEngine;

public class DesignEvent : BaseEvent
{
    public DesignEventData Data;

}

[CreateAssetMenu(fileName = "Event", menuName = "Game/Design Event")]
public class DesignEventData : ScriptableObject
{
    private DesignEvent mEvent = new DesignEvent();
    public void Trigger()
    {
        mEvent.Data = this;
        EventManager<DesignEvent>.TriggerEvent(mEvent);
    }
}
