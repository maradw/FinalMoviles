using System.Collections.Generic;
using UnityEngine;

public class StaticObjectPooling : MonoBehaviour
{
    [SerializeField] private PoolObject prefab;
    [SerializeField] private int poolSize = 10;

    private Queue<PoolObject> pool = new Queue<PoolObject>();

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            PoolObject obj = Instantiate(prefab, transform);
            obj.OnObjectReturn();
            pool.Enqueue(obj);
        }
    }

    public PoolObject GetObject()
    {
        if (pool.Count > 0)
        {
            PoolObject obj = pool.Dequeue();
            obj.OnObjectReuse();
            return obj;
        }
        return null;
    }

    public void ReturnObject(PoolObject obj)
    {
        obj.OnObjectReturn();
        pool.Enqueue(obj);
    }
}

