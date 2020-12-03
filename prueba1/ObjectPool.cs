
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject Prefab;
    private List<GameObject> mPool = new List<GameObject>();

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
