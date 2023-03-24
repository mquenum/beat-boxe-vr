using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> PooledObjects;

    private void Awake()
    {
        // allow access to this script without having to get a component from a GameObject
        SharedInstance = this;
        PooledObjects = new List<GameObject>();
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < PooledObjects.Count; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }

        return null;
    }

    // add object creation here
}
