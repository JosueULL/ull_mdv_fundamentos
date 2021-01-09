using UnityEngine;

public class ObjectPoolSpawner : MonoBehaviour
{
    public ObjectPool Pool;
    public Transform SpawnPoint;

    public void Spawn()
    {
        GameObject go = Pool.Get();
        go.transform.position = SpawnPoint.position;
        go.transform.rotation = SpawnPoint.rotation;
        go.SetActive(true);
    }
}
