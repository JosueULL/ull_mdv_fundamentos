using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public void Play(AudioClip clip)
    {
        AudioManager.Instance.Play(clip);
    }
}
