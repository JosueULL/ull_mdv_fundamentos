using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    [System.Serializable]
    public class AnimationFX
    {
        public string FXId;
        public ObjectPool Pool;
        public Transform Parent;
        public bool DetachFromParent;
    }

    public List<AnimationFX> Effects;

    // --------------------------------------------------------------------

    public void PlayFX(string fxId)
    {
        foreach(AnimationFX fx in Effects)
        {
            if (fxId == fx.FXId)
            {
                GameObject fxInstance = fx.Pool.Get();
                fxInstance.transform.position = fx.Parent.position;
                fxInstance.transform.rotation = fx.Parent.rotation;
                if (!fx.DetachFromParent)
                    fxInstance.transform.parent = fx.Parent;

                fxInstance.SetActive(true);
            }
        }    
    }

    // --------------------------------------------------------------------

    public void PlaySound(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
    }
}
