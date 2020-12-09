using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private static readonly int sSpeedXHash = Animator.StringToHash("SpeedX");
    private static readonly int sSpeedYHash = Animator.StringToHash("SpeedY");
    private static readonly int sSpeedHash = Animator.StringToHash("Speed");
    private static readonly float sMinSpeedThreshold = 0.01f;

    public float MoveSpeed;

    private Rigidbody2D mRigidbody;
    private Animator mAnimator;
    private Vector2 mVelocity;

    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        
        mRigidbody.MovePosition(mRigidbody.position + mVelocity);
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        mVelocity = new Vector2(h, v) * MoveSpeed;
        float speed = mVelocity.magnitude;

        if (speed > sMinSpeedThreshold)
        { 
            mAnimator.SetFloat(sSpeedXHash, mVelocity.x);
            mAnimator.SetFloat(sSpeedYHash, mVelocity.y);
        }

        mAnimator.SetFloat(sSpeedHash, speed);
    }
}