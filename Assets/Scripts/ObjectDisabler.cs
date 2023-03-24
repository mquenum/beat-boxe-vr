using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    private GameObject _collisionObject;
    private Rigidbody _collisionObjectRb;

    // using OnCollisionEnter for now
    private void OnCollisionEnter(Collision collision)
    {
        // move to spawner 
        int layer = gameObject.layer;

        _collisionObject = collision.gameObject;
        
        // if the collision object is on the "Opponent" layer
        if (LayerMask.LayerToName(layer) == "Opponent")
        {
            _collisionObjectRb = _collisionObject.GetComponent<Rigidbody>();
            // disable the collision object
            _collisionObject.SetActive(false);
            // reset the rigidbody parameters
            _collisionObjectRb.velocity = Vector3.zero;
            _collisionObjectRb.isKinematic = true;
        }
    }
}
