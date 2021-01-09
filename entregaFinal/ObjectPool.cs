
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject Prefab;
    public int InitialSize;

    private List<GameObject> mPool = new List<GameObject>();

    // --------------------------------------------------------------------

    private void Awake()
    {
        for (int i = 0; i < InitialSize; ++i)
        {
            GameObject go = Instantiate(Prefab);
            go.SetActive(false);
            mPool.Add(go);
        }
    }

    // --------------------------------------------------------------------

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

    // --------------------------------------------------------------------

    public void ReturnAll()
    {
        foreach (GameObject poolObj in mPool)
            poolObj.gameObject.SetActive(false);
    }
}