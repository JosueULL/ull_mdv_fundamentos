using UnityEngine;

public class UIDialog : MonoBehaviour
{
    public AppearingText Text;
    public TMPro.TMP_Text CharacterName;

    private int mCurrentLine;
    private DialogData mData;
    private AudioSource mAudioSource;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
    }

    // --------------------------------------------------------------------

    private void OnEnable()
    {
        if (!mData)
        {
            gameObject.SetActive(false);
        }
        else
        {
            mCurrentLine = -1;
            if (mData.OnDialogStartEvent)
                mData.OnDialogStartEvent.Trigger();
            ProcessNext();
        }
    }

    // --------------------------------------------------------------------

    public void ShowLines(DialogData data)
    {
        mData = data;
        gameObject.SetActive(true);
    }

    // --------------------------------------------------------------------

    public void ProcessNext()
    {
        if (mCurrentLine >= mData.Lines.Count-1)
        {
            gameObject.SetActive(false);
            if (mData.OnDialogEndEvent)
                mData.OnDialogEndEvent.Trigger();
            return;
        }

        ++mCurrentLine;
        CharacterName.text = mData.Lines[mCurrentLine].CharacterName;
        Text.Show(mData.Lines[mCurrentLine].LineText);

        if (mData.Lines[mCurrentLine].Clip)
        {
            mAudioSource.Stop();
            mAudioSource.PlayOneShot(mData.Lines[mCurrentLine].Clip);
        }
    }

    // --------------------------------------------------------------------

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Text.HasShownAll)
                ProcessNext();
            else
                Text.ShowAllText();
        }
    }
}
