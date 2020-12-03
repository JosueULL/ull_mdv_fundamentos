using UnityEngine;

public class DisableInTime : MonoBehaviour
{
    public float MinLifetime = 1;
    public float MaxLifetime = 3;
    private float mLifeTime;

    void OnEnable()
    {
        mLifeTime = Random.Range(MinLifetime, MaxLifetime);
    }

    void Update()
    {
        mLifeTime -= Time.deltaTime;
        if (mLifeTime <= 0)
            gameObject.SetActive(false);
    }
}
