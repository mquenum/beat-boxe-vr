using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    private GameObject _collisionObject;
    private ObjectSpawner _spawner;
    public float DistanceToCenter;
    public static ObjectDisabler SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _spawner = ObjectSpawner.SharedInstance;
    }

    // using OnCollisionEnter for now
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        // if the collision object has the "Opponent" tag
        if (collision.gameObject.CompareTag("Opponent"))
        {
            ContactPoint contact = collision.GetContact(0);
            Vector3 center = collision.transform.position;
            Vector3 point = contact.point;
            DistanceToCenter = Vector3.Distance(center, point);

            Debug.Log("Distance: " + DistanceToCenter);

            _collisionObject = collision.gameObject;
            _spawner.ResetObj(_collisionObject);
        }
    }

/*    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        // if the collision object has the "Opponent" tag
        if (other.gameObject.CompareTag("Opponent"))
        {
            _collisionObject = other.gameObject;
            _spawner.ResetObj(_collisionObject);
        }
    }*/
}
