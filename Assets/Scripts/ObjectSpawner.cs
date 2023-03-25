using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    private ObjectPooler _objectPooler;
    public static ObjectSpawner SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
        _objectPooler = ObjectPooler.SharedInstance;
    }

    public void Spawn(Transform lane, List<GameObject> requiredPool, Quaternion rotation)
    {
        GameObject obj = _objectPooler.GetPooledObject(requiredPool);

        obj.transform.position = lane.position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
    }

    public void ResetObj(GameObject obj)
    {
        Rigidbody _objRb = obj.GetComponent<Rigidbody>();

        // disable the collision object
        obj.SetActive(false);
        // reset the rigidbody parameters
        _objRb.velocity = Vector3.zero;
        _objRb.isKinematic = true;
    }
}
