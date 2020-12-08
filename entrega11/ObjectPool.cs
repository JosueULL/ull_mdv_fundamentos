
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject Prefab;
    public int InitialPoolSize;
    private List<GameObject> mPool = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < InitialPoolSize; ++i)
        {
            GameObject go = Instantiate(Prefab);
            mPool.Add(go);
            go.gameObject.SetActive(false);
        }    
    }

    public GameObject Get()
    {
        if (mPool.Count > 0)
        {
            foreach (GameObject poolObj in mPool)
                if (!poolObj.activeSelf)
                    return poolObj;
        }

        GameObject go = Instantiate(Prefab);
        mPool.Add(go);
        return go;
    }
}
