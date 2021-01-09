using UnityEngine;

public class TweenPosition : TweenBase
{
    public Vector3 Offset;
    
    private Vector3 mOrigin;
    private Vector3 mInitPos;
    
    // --------------------------------------------------------------------

    private void Awake() {
        mInitPos = transform.position;
    }

    // --------------------------------------------------------------------

    private void OnEnable()
    {
        CurrentTime = 0;
        mOrigin = transform.position;
    }

    // --------------------------------------------------------------------

    private void Update()
    {
        CurrentTime += Time.deltaTime;
        transform.position = Vector3.Lerp(mOrigin, mOrigin + Offset, CurrentTime / Duration);

        if (CurrentTime >= Duration)
        {
            switch (Loop)
            {
                case TweenLoopMode.PingPong:
                    mOrigin = mOrigin + Offset;
                    Offset = -Offset;
                    CurrentTime = 0;
                    break;
                case TweenLoopMode.Repeat:
                    CurrentTime = 0;
                    break;
                case TweenLoopMode.None:
                    enabled = false;
                    break;
            }
        }
    }

    // --------------------------------------------------------------------

    public void Reset()
    {
        enabled = false;
        transform.position = mInitPos;
    }

    // --------------------------------------------------------------------

    public void Invert()
    {
        Offset = -Offset;
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