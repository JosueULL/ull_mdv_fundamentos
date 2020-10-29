using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static readonly float sInterpolation = 10;
    private static readonly int sSpeedHash = Animator.StringToHash("Speed");

    [SerializeField] private float MoveSpeed = 2;
    [SerializeField] private float TurnSpeed = 200;

    private Animator mAnimator = null;
    private float mCurrentV = 0;
    private float mCurrentH = 0;
    private Vector3 mCurrentDir = Vector3.zero;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    // --------------------------------------------------------------------

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Transform camera = Camera.main.transform;   // TODO - This is not very efficient, but we don't have a camera manager yet

        mCurrentV = Mathf.Lerp(mCurrentV, v, Time.deltaTime * sInterpolation);
        mCurrentH = Mathf.Lerp(mCurrentH, h, Time.deltaTime * sInterpolation);

        Vector3 direction = camera.forward * mCurrentV + camera.right * mCurrentH;

        float directionLength = direction.magnitude;
        direction.y = 0;
        direction = direction.normalized * directionLength;

        if (direction != Vector3.zero)
        {
            mCurrentDir = Vector3.Slerp(mCurrentDir, direction, Time.deltaTime * sInterpolation);

            transform.rotation = Quaternion.LookRotation(mCurrentDir);
            transform.position += mCurrentDir * MoveSpeed * Time.deltaTime;

            mAnimator.SetFloat(sSpeedHash, direction.magnitude);
        }
    }
}