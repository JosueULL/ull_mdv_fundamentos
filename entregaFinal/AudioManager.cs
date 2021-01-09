using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource Music;

    private static readonly float sMinSameClipThreshold = 0.05f;
    private static readonly int sNumChannels = 4;

    private Dictionary<AudioClip, float> mPlayTimes = new Dictionary<AudioClip, float>();
    private List<AudioSource> mChannels = new List<AudioSource>(sNumChannels);
    private int mChannelIndex;

    private float mInitMusicVolume;

    // --------------------------------------------------------------------

    void Awake()
    {
        mInitMusicVolume = Music.volume;
        for (int i = 0; i < sNumChannels; ++i)
            mChannels.Add(gameObject.AddComponent<AudioSource>());
    }

    // --------------------------------------------------------------------

    public void Play(AudioClip clip)
    {
        if (!mPlayTimes.ContainsKey(clip) || mPlayTimes[clip] < (Time.time - sMinSameClipThreshold))
        {
            mChannels[mChannelIndex].PlayOneShot(clip);
            ++mChannelIndex;
            if (mChannelIndex >= sNumChannels)
                mChannelIndex = 0;

            mPlayTimes[clip] = Time.time;
        }
    }

    // --------------------------------------------------------------------

    public void FadeOutMusic(float time)
    {
        StartCoroutine(Fade(Music, Music.volume, 0, time));
    }

    // --------------------------------------------------------------------

    public void FadeInMusic(float time)
    {
        StartCoroutine(Fade(Music, Music.volume, mInitMusicVolume, time));
    }

    // --------------------------------------------------------------------

    private IEnumerator Fade(AudioSource source, float from, float to, float fadeTime)
    {
        
        float time = 0;
        WaitForEndOfFrame endFrame = new WaitForEndOfFrame();
        while (time < fadeTime)
        {
            source.volume = Mathf.Lerp(from, to, time / fadeTime);
            yield return endFrame;
            time += Time.deltaTime;
        }
        source.volume = to;
    }

    // --------------------------------------------------------------------

    public void SetMusic(AudioClip clip)
    {
        Music.clip = clip;
        Music.Play();
    }

}
