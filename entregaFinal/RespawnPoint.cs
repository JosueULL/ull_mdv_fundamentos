using UnityEngine;
using UnityEngine.Events;

public class RespawnActivatedEvent : UnityEvent<RespawnPoint> {}

public class RespawnPoint : MonoBehaviour
{
    public ParticleSystem ActivationFX;
    public AudioClip ActivationClip;

#if UNITY_EDITOR
    [Header("------ DEV ------")]
    public bool StartPlayerHere;
#endif

    public RespawnActivatedEvent OnActivated = new RespawnActivatedEvent();

    private ParticleSystem[] mPSystems;

    // --------------------------------------------------------------------

    void Awake()
    {
        mPSystems = GetComponentsInChildren<ParticleSystem>();

#if UNITY_EDITOR
        // Debug option that allows to mark a respawn point as the player start point
        if (StartPlayerHere)
        {
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            player.transform.position = transform.position;
        }
#endif
    }

    // --------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(ParticleSystem s in mPSystems)
        {
            s.startColor = Color.white;
        }

        ActivationFX.Play();
        AudioManager.Instance.Play(ActivationClip);
        OnActivated.Invoke(this);
    }
}
