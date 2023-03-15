using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private int _amountToSpawn;
    private List<GameObject> _pool;

    void Start()
    {
        // get the pool from the ObjectPooler
        _pool = ObjectPooler.SharedInstance.PooledObjects;

        for (int i = 0; i < _amountToSpawn; i++)
        {
            // instantiate object in variable
            GameObject obj = Instantiate(_objectToSpawn);

            // deactivate object
            obj.SetActive(false);
            // add object to the pool
            _pool.Add(obj);
        }
    }

    // function to activate an object from the pool
    public void ActivatePooledObj()
    {
        // get the first inactive GameObject in the pool
        GameObject obj = ObjectPooler.SharedInstance.GetPooledObject();

        // if there is any inactive GameObject in the pool
        if (obj != null)
        {
            // activate that game object
            obj.SetActive(true);
        }
    }
}
