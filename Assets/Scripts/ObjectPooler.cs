using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> PooledObjects;
    /*public GameObject ObjectToPool;
    public int AmountToPool;*/

    private void Awake()
    {
        // allow access to this script without having to get a component from a GameObject
        SharedInstance = this;
        PooledObjects = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        

        /*for (int i = 0; i < AmountToPool; i++)
        {
            GameObject obj = Instantiate(ObjectToPool);

            obj.SetActive(false);
            PooledObjects.Add(obj);
        }*/
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
}
