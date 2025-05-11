using UnityEngine;

public  class PoolObject : MonoBehaviour
{
    public virtual void OnObjectReuse()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnObjectReturn()
    {
        gameObject.SetActive(false);
    }

}
