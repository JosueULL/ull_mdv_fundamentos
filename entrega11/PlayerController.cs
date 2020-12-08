using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int sInMotionHash = Animator.StringToHash("InMotion");
    private static readonly int sGroundedHash = Animator.StringToHash("Grounded");

    public float JumpForce = 10;

    private Rigidbody2D mRigidbody;
    private Animator mAnimator;
    private bool mGrounded = false;

    void Awake()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        mAnimator.SetBool(sInMotionHash, true);
    }

    void Update()
    {
        if (mGrounded && Input.GetButtonDown("Jump"))
        {
            mRigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        mAnimator.SetBool(sGroundedHash, true);
        mGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        mAnimator.SetBool(sGroundedHash, false);
        mGrounded = false;
    }
}
