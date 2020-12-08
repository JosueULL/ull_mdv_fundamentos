using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public ObjectPool Pool;

    public float MinTime;
    public float MaxTime;

    private float mCurrentTime;
    
    void Start()
    {
        mCurrentTime = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        mCurrentTime -= Time.deltaTime;
        if (mCurrentTime < 0)
        {
            mCurrentTime = Random.Range(MinTime, MaxTime);
            Transform t = GetRandomSpawnPoint();

            GameObject go = Pool.Get();
            go.transform.position = t.position;
            go.SetActive(true);

            mCurrentTime = Random.Range(MinTime, MaxTime);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        if (SpawnPoints.Length == 0)
            return transform;

        return SpawnPoints[Random.Range(0, SpawnPoints.Length - 1)];
    }
}
