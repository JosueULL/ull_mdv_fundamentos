using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static readonly float sInterpolation = 20;
    private static readonly int sSpeedHash = Animator.StringToHash("Speed");
    private static readonly int sVVelocityHash = Animator.StringToHash("VerticalVel");
    private static readonly int sJumpHash = Animator.StringToHash("Jump");
    private static readonly int sGroundedHash = Animator.StringToHash("Grounded");

    [SerializeField] private float MoveSpeed = 2;
    [SerializeField] private AnimationCurve JumpAcceleration;

    private Animator mAnimator;
    private SpriteRenderer mSpriteRenderer;
    private float mCurrentH;
    private float mCurrentV;
    private float mGroundPos;
    private bool mJumping;
    private float mJumpProgress;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponentInChildren<Animator>();
        mSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        mGroundPos = transform.position.y;
        mJumping = false;
    }

    // --------------------------------------------------------------------

    private void FixedUpdate()
    {
        UpdateJump();

        if (mCurrentH != 0f || mCurrentV != 0f)
        {
            Vector3 newPos = transform.position + Vector3.right * mCurrentH * MoveSpeed * Time.deltaTime + Vector3.up * mCurrentV * Time.deltaTime;
            if (newPos.y < mGroundPos) // Limit to ground position
                newPos.y = mGroundPos;

            transform.position = newPos;
        }
    }

    // --------------------------------------------------------------------

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        mCurrentH = Mathf.Lerp(mCurrentH, h, Time.deltaTime * sInterpolation);

        if (Input.GetButtonDown("Jump") && mCurrentV == 0f)
        {
            mJumping = true;
            mJumpProgress = 0;
            mAnimator.SetTrigger(sJumpHash);
            mAnimator.SetBool(sGroundedHash, false);
        }

        mSpriteRenderer.flipX = mCurrentH < 0;
        mAnimator.SetFloat(sSpeedHash, Mathf.Abs(mCurrentH));
        mAnimator.SetFloat(sVVelocityHash, mCurrentV);
    }

    // --------------------------------------------------------------------

    private void UpdateJump()
    {
        if (mJumping)
        {
            mJumpProgress += Time.deltaTime;
            mCurrentV += JumpAcceleration.Evaluate(mJumpProgress);
            if (mJumpProgress >= JumpAcceleration.keys[JumpAcceleration.length - 1].time)
                mJumping = false;
        }
        else if (transform.position.y > mGroundPos)// Apply gravity
        {
            mCurrentV -= 1;
        }
        else // Grounded
        {
            mCurrentV = 0;
            mAnimator.SetBool(sGroundedHash, true);
        }
    }

    // --------------------------------------------------------------------

    private void OnDrawGizmos()
    {
        Vector3 pos = transform.position;
        pos.y = mGroundPos;
        Gizmos.DrawLine(pos - Vector3.right * 100, pos + Vector3.right * 100);
    }
}