using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static readonly float sPlayerGravity = 1;
    private static readonly float sMinVelThreshold = 0.1f;
    private static readonly float sInterpolation = 20;
    private static readonly float sBigLandTime = 1f;
    private static readonly float sSmallLandTime = 0.25f;

    private static readonly int sSpeedHash = Animator.StringToHash("Speed");
    private static readonly int sVVelocityHash = Animator.StringToHash("VerticalVel");
    private static readonly int sJumpHash = Animator.StringToHash("Jump");
    private static readonly int sGroundedHash = Animator.StringToHash("Grounded");

    [SerializeField] private float MoveSpeed = 2;
    [SerializeField] private float MaxSpeed = 10;
    [SerializeField] private AnimationCurve JumpVelocity;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private ObjectPool BigLandFXPool;
    [SerializeField] private ObjectPool SmallLandFXPool;

    private Animator mAnimator;
    private Rigidbody2D mRigidbody;
    private BoxCollider2D mCollider;
    private SpriteRenderer mSpriteRenderer;
    private float mCurrentH;
    private float mCurrentV;

    private bool mGrounded;
    private bool mJumping;
    private float mJumpProgress;
    private float mAirTime;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mRigidbody = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<BoxCollider2D>();
        mAnimator = GetComponentInChildren<Animator>();
        mSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // --------------------------------------------------------------------

    private void OnEnable()
    {
        mGrounded = false;
        mJumping = false;
        mAirTime = 0;
    }

    // --------------------------------------------------------------------

    private void FixedUpdate()
    {
        UpdateJump();

        if (!mJumping)
            CheckGround();

        if (mCurrentH != 0f || mCurrentV != 0f)
        {
            Vector2 newVel = new Vector2(mCurrentH * MoveSpeed, mCurrentV);
            float speed = newVel.magnitude;
            if (speed < sMinVelThreshold)
                newVel = Vector2.zero;

            newVel.x = Mathf.Clamp(newVel.x, -MaxSpeed, MaxSpeed);
            newVel.y = Mathf.Clamp(newVel.y, -MaxSpeed, MaxSpeed);

            mRigidbody.velocity = newVel;
        }
    }

    // --------------------------------------------------------------------

    private void CheckGround()
    {
        const float groundDist = 0.1f;
        float playerWidth = mCollider.size.x * 0.5f;
        Vector2 origin1 = (Vector2)transform.position + Vector2.right * playerWidth;
        Vector2 origin2 = (Vector2)transform.position - Vector2.right * playerWidth;

        ContactFilter2D filter = new ContactFilter2D()
        {
            useTriggers = false,
            useLayerMask = true,
            useDepth = false,
            layerMask = GroundLayer
        };

        if (CheckGroundHit(origin1, filter, groundDist) || CheckGroundHit(origin2, filter, groundDist))
        {
            if (!mGrounded)
                Ground();
        }
        else
        {
            mGrounded = false;
        }

#if UNITY_EDITOR
        Debug.DrawLine(origin1, origin1 - Vector2.up * groundDist, mGrounded ? Color.green : Color.red);
        Debug.DrawLine(origin2, origin2 - Vector2.up * groundDist, mGrounded ? Color.green : Color.red);
#endif
    }

    // --------------------------------------------------------------------

    public bool CheckGroundHit(Vector2 origin, ContactFilter2D filter, float dist)
    {
        RaycastHit2D[] hits = new RaycastHit2D[1];
        if (Physics2D.Raycast(origin, -Vector2.up, filter, hits, dist) > 0)
        {
            Debug.DrawLine(hits[0].point, hits[0].point + hits[0].normal, Color.blue);
            return Vector2.Dot(hits[0].normal, Vector2.up) > 0.5;
        }
        return false;
    }

    // --------------------------------------------------------------------

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        mCurrentH = Mathf.Lerp(mCurrentH, h, Time.deltaTime * sInterpolation);

        if (Input.GetButtonDown("Jump") && mGrounded)
        {
            mJumping = true;
            mJumpProgress = 0;
            mGrounded = false;
            mAirTime = 0;
            mAnimator.SetTrigger(sJumpHash);
        }

        mSpriteRenderer.flipX = mCurrentH < 0;
        float speed = Mathf.Abs(mCurrentH);
        if (speed < sMinVelThreshold)
            speed = 0f;
        mAnimator.SetFloat(sSpeedHash, speed);
        mAnimator.SetFloat(sVVelocityHash, mCurrentV);
        mAnimator.SetBool(sGroundedHash, mGrounded);

        if (!mGrounded)
            mAirTime += Time.deltaTime;
    }

    // --------------------------------------------------------------------

    private void OnDisable()
    {
        mAnimator.SetFloat(sSpeedHash, 0);
        mAnimator.SetFloat(sVVelocityHash, 0);
        mAnimator.SetBool(sGroundedHash, true);
        mRigidbody.velocity = Vector3.zero;
    }


    // --------------------------------------------------------------------

    private void UpdateJump()
    {
        if (mJumping)
        {
            mJumpProgress += Time.deltaTime;
            mCurrentV += JumpVelocity.Evaluate(mJumpProgress);
            if (mJumpProgress >= JumpVelocity.keys[JumpVelocity.length - 1].time)
                mJumping = false;
        }
        else if (!mGrounded)
        {
            mCurrentV -= sPlayerGravity;
        }
        else // Grounded
        {
            mCurrentV = 0;
            mAnimator.SetBool(sGroundedHash, true);
        }
    }

    // --------------------------------------------------------------------

    private void Ground()
    {
        mGrounded = true;
        GameObject landFX = null;
        if (mAirTime > sBigLandTime)
        {
            landFX = BigLandFXPool.Get();
        }
        else if (mAirTime > sSmallLandTime)
        {
            landFX = SmallLandFXPool.Get();
        }

        if (landFX != null)
        {
            landFX.transform.position = transform.position;
            landFX.transform.rotation = Quaternion.identity;
            landFX.transform.parent = null;
            landFX.SetActive(true);
        }

        mAirTime = 0;
    }
}