using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private GameObject _obstacleDirect;
    [SerializeField] private GameObject _dodge;
    [SerializeField] private GameObject _counter;
    [SerializeField] private int _amountToSpawn;
    public static ObjectPooler SharedInstance;
    public List<GameObject> PooledObstacles;
    public List<GameObject> PooledObstaclesDirect;
    public List<GameObject> PooledDodges;
    public List<GameObject> PooledCounter;

    private void Awake()
    {
        // allow access to this script without having to get a component from a GameObject
        SharedInstance = this;

        PooledObstacles = new List<GameObject>();
        PooledObstaclesDirect = new List<GameObject>();
        PooledDodges = new List<GameObject>();
        PooledCounter = new List<GameObject>();

        for (int i = 0; i < _amountToSpawn; i++)
        {
            PopulatePools(PooledObstacles, _obstacle);
            PopulatePools(PooledObstaclesDirect, _obstacleDirect);
            PopulatePools(PooledDodges, _dodge);
            PopulatePools(PooledCounter, _counter);
        }
    }

    private void PopulatePools(List<GameObject> pool, GameObject objToSpawn)
    {
        GameObject obj = Instantiate(objToSpawn);

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
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return null;
    }
}
