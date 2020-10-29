using UnityEngine;

public class Slime : MonoBehaviour
{
    private static readonly int sDieHash = Animator.StringToHash("Die");
    private Animator mAnimator;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponentInChildren<Animator>();
    }

    // --------------------------------------------------------------------

    private void Update()
    {
        if (Input.GetButtonDown("KillAll"))
        {
            mAnimator.SetTrigger(sDieHash);
        }
    }
}