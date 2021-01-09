using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TriggerListener : MonoBehaviour
{
    [FormerlySerializedAs("OnTrigger")]
    public UnityEvent OnTriggerEnter;
    public UnityEvent OnTriggerExit;

    // --------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTriggerEnter.Invoke();
    }

    // --------------------------------------------------------------------

    private void OnTriggerExit2D(Collider2D other)
    {
        OnTriggerExit.Invoke();
    }
}