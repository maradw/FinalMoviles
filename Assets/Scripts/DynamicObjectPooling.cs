using System.Collections.Generic;
using UnityEngine;

public class DynamicObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private Queue<GameObject> pool = new Queue<GameObject>();

    public GameObject GetObject()
    {
        GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            obj = Instantiate(prefab, transform);
        }

        PoolObject poolObj = obj.GetComponent<PoolObject>();
        if (poolObj != null)
            poolObj.OnObjectReuse();
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        PoolObject poolObj = obj.GetComponent<PoolObject>();
        if (poolObj != null) poolObj.OnObjectReturn();
        pool.Enqueue(obj);
    }
}

