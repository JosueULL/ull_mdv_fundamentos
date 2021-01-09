using UnityEngine;
using UnityEngine.Events;

public class AppearingText : MonoBehaviour
{
    public bool AppearOnEnable = false;
    public AudioClip CharacterSound;
    public float TimePerCharacter = 0.1f;
    public float TimePerSound = 0.1f;

    public UnityEvent OnStartShowing;
    public UnityEvent OnShowAll;

    private TMPro.TextMeshProUGUI mText;

    private float mCurrentTime;
    private float mAudioTime;
    private AudioSource mSource;

    public bool HasShownAll { get { return !enabled; } }

    // --------------------------------------------------------------------

    private void Awake()
    {
        if (!AppearOnEnable)
            enabled = false;

        mText = GetComponent<TMPro.TextMeshProUGUI>();
        mSource = GetComponentInParent<AudioSource>();
    }

    // --------------------------------------------------------------------

    private void OnEnable()
    {
        if (AppearOnEnable)
        {
            Show(mText.text);
        }
    }

    // --------------------------------------------------------------------

    public void Show(string text)
    {
        mCurrentTime = 0;

        mText.text = text;
        mText.maxVisibleCharacters = 0;
        OnStartShowing?.Invoke();

        enabled = true;
    }

    // --------------------------------------------------------------------

    public void Clear()
    {
        mText.text = "";
        enabled = false;
    }

    // --------------------------------------------------------------------

    protected virtual void Update()
    {
        mCurrentTime += Time.deltaTime;
        if (mCurrentTime > TimePerCharacter)
        {
            mCurrentTime = 0f;
            mText.maxVisibleCharacters = mText.maxVisibleCharacters + 1;
            if (mText.maxVisibleCharacters >= mText.text.Length)
            {
                enabled = false;
                OnShowAll?.Invoke();
            }
        }

        mAudioTime += Time.deltaTime;
        if (mAudioTime > TimePerSound && mText.maxVisibleCharacters > 0 && mText.text[mText.maxVisibleCharacters - 1] != ' ')
        {
            mAudioTime = 0;
            if (CharacterSound)
                mSource.PlayOneShot(CharacterSound);
        }
    }

    // --------------------------------------------------------------------

    public void ShowAllText()
    {
        mText.maxVisibleCharacters = mText.text.Length;
        enabled = false;
        OnShowAll?.Invoke();
    }
}