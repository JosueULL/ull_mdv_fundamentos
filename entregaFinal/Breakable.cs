using UnityEngine;

public class Breakable : MonoBehaviour
{
    private static readonly int sBreakHash = Animator.StringToHash("Break");

    public AudioClip BreakClip;

    private Animator mAnimator;
    private Collider2D mCollider;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mAnimator = GetComponentInChildren<Animator>();
        mCollider = GetComponent<Collider2D>();
    }

    // --------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D other)
    {
        mAnimator.SetTrigger(sBreakHash);
        AudioManager.Instance.Play(BreakClip);
        mCollider.enabled = false;
    }
}