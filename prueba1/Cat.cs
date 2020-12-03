using UnityEngine;

public class OnCatPickedUpEvent : BaseEvent { }

public class Cat : MonoBehaviour
{
    private SpriteRenderer mSprite;

    private void Awake()
    {
        mSprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        EventManager<OnRockHitEvent>.StartListening(OnRockHit);
    }


    private void OnDisable()
    {
        EventManager<OnRockHitEvent>.StopListening(OnRockHit);
    }


    private void OnRockHit(OnRockHitEvent e)
    {
        mSprite.flipX = !mSprite.flipX;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager<OnCatPickedUpEvent>.TriggerEvent();
        gameObject.SetActive(false);
    }
}
