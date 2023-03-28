using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] private int _amountToInstantiate;
    public List<GameObject> _pool = new List<GameObject>();
    public List<GameObject> Pool { get { return _pool; } }
    public static Pooler SharedInstance;

    private void Awake()
    {
        // allow access to this script without having to get a component from a GameObject
        SharedInstance = this;

        for (int i = 0; i < _amountToInstantiate; i++)
        {
            PopulatePools(_pool, _prefab);
        }
    }

    private void PopulatePools(List<GameObject> pool, GameObject objToPool)
    {
        GameObject obj = Instantiate(objToPool);

        // set current gameobject as parent of the created object
        obj.transform.SetParent(transform);
        // deactivate object
        obj.SetActive(false);
        // add object to the pool
        pool.Add(obj);
    }

    public GameObject GetPooledObject(List<GameObject> pool)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].gameObject.activeInHierarchy)
            {
                return pool[i].gameObject;
            }
        }

        return null;
    }
}
