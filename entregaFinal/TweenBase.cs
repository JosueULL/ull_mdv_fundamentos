using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TweenLoopMode
{
    None,
    PingPong,
    Repeat
}

public abstract class TweenBase : MonoBehaviour
{
    public float Duration;
    public TweenLoopMode Loop;

    protected float CurrentTime;
}
