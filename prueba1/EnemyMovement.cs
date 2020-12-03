using UnityEngine;

public class OnEnemyContactPlayer : BaseEvent { }

public class EnemyMovement : MonoBehaviour
{
    private static readonly float sDistanceThreshold = 0.1f;
    public float MoveSpeed = 0.1f;
    
    public float MinMovement = 5;
    public float MaxMovement = 10;

    private Vector2 mTarget;
    private Rigidbody2D mRigidbody;
    
    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        
    }

    void OnEnable()
    {
        mTarget = transform.position + (Vector3)(Random.insideUnitCircle * Random.Range(MinMovement, MaxMovement));
        EventManager<OnRockHitEvent>.StartListening(OnRockHit);
    }

    private void OnDisable()
    {
        EventManager<OnRockHitEvent>.StopListening(OnRockHit);
    }

    private void OnRockHit(OnRockHitEvent e)
    {
        PushBack();
    }

    void FixedUpdate()
    {
        Vector2 toTarget = mTarget - mRigidbody.position;
        toTarget.Normalize();
        mRigidbody.MovePosition(mRigidbody.position + toTarget * MoveSpeed);

        if (Vector3.Distance(mRigidbody.position, mTarget) < sDistanceThreshold)
            gameObject.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager<OnEnemyContactPlayer>.TriggerEvent();
        gameObject.SetActive(false);
    }

    public void PushBack()
    {
        Vector2 toTarget = mTarget - mRigidbody.position;
        toTarget.Normalize();
        mTarget = mRigidbody.transform.position - (Vector3)(toTarget * 2);
        mRigidbody.MovePosition(mRigidbody.position - toTarget  * 10);
        Debug.Log("Push!");
    }

}
