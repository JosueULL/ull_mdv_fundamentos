using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Dialog", menuName = "Game/Dialog")]
public class DialogData : ScriptableObject
{
    [System.Serializable]
    public class DialogLine
    {
        public string CharacterName;
        public string LineText;
        public AudioClip Clip;
    }

    public List<DialogLine> Lines;
    public DesignEventData OnDialogStartEvent;
    public DesignEventData OnDialogEndEvent;
}
