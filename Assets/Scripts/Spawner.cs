using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Pooler> _poolers;
    private Pooler _pooler;
    public List<Pooler> Poolers { get { return _poolers; } }

    private void Start()
    {
        _pooler = Pooler.SharedInstance;
    }

    public void Spawn(Transform lane, List<GameObject> requiredPool, Quaternion rotation)
    {
        GameObject obj = _pooler.GetPooledObject(requiredPool);

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
