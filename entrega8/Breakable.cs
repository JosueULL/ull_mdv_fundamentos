using UnityEngine;

public class Breakable : MonoBehaviour
{
    private static readonly int sBreakHash = Animator.StringToHash("Break");

    private Animator mAnimator;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponentInChildren<Animator>();
    }

    // --------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D other)
    {
        mAnimator.SetTrigger(sBreakHash);
    }
}