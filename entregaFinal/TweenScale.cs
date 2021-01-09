using UnityEngine;

public class TweenScale : TweenBase
{
    public Vector3 Scale;
    private Vector3 mOrigin;

    // --------------------------------------------------------------------

    void OnEnable()
    {
        CurrentTime = 0;
        mOrigin = transform.localScale;
    }


    // --------------------------------------------------------------------

    void Update()
    {
        CurrentTime += Time.deltaTime;
        transform.localScale = Vector3.Lerp(mOrigin, Scale, CurrentTime / Duration);

        if (CurrentTime >= Duration)
        {
            switch (Loop)
            {
                case TweenLoopMode.PingPong:
                    Vector3 tmp = mOrigin;
                    mOrigin = Scale;
                    Scale = tmp;
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
}
