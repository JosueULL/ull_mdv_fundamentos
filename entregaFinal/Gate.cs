using UnityEngine;

public class Gate : MonoBehaviour
{
    public TweenPosition OpenTween;
    public AudioClip OpenClip;

    public void Open()
    {
        AudioManager.Instance.Play(OpenClip);
        OpenTween.enabled = true;
    }
}
