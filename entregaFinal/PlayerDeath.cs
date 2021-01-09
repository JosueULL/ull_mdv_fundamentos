using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public ObjectPool DeathFX;
    public AudioClip DeathClip;

    private Health mHealth;

    // --------------------------------------------------------------------

    private void Awake()
    {
        mHealth = GetComponent<Health>();
        mHealth.OnHealthDepleted.AddListener(OnHealthDepleted);
    }

    // --------------------------------------------------------------------

    private void OnDestroy()
    {
        mHealth.OnHealthDepleted.RemoveListener(OnHealthDepleted);
    }

    // --------------------------------------------------------------------

    private void OnHealthDepleted()
    {
        if (DeathFX)
        {
            GameObject deathFX = DeathFX.Get();
            deathFX.transform.position = transform.position;
            deathFX.transform.parent = null;
            deathFX.SetActive(true);
        }

        if (DeathClip)
            AudioManager.Instance.Play(DeathClip);

        gameObject.SetActive(false);

        GameManager.Instance.RespawnPlayer(transform);
        GameManager.Instance.RemoveCurrency(5);
    }

}
