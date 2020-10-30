using UnityEngine;

public class Slime : MonoBehaviour
{
    private static readonly int sDieHash = Animator.StringToHash("Die");

    [SerializeField] private float MoveSpeed;

    private Rigidbody2D mRigidbody;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
    }

    // --------------------------------------------------------------------

    private void FixedUpdate()
    {
        mRigidbody.AddForce(-Vector3.right * MoveSpeed * Time.deltaTime);
    }
}