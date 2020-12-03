using UnityEngine;

public class TweenPosition : MonoBehaviour
{
    public Vector3 Offset;
    public float Duration;

    private Vector3 mOrigin;
    private float mTime;

    // --------------------------------------------------------------------

    private void OnEnable()
    {
        mTime = 0;
        mOrigin = transform.position;
    }

    // --------------------------------------------------------------------

    private void Update()
    {
        mTime += Time.deltaTime;
        transform.position = Vector3.Lerp(mOrigin, mOrigin + Offset, mTime / Duration);

        if (mTime >= Duration)
            enabled = false;
    }

    // --------------------------------------------------------------------

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Offset);
        Gizmos.DrawWireCube(transform.position + Offset, Vector3.one * 0.25f);
    }

#endif
}