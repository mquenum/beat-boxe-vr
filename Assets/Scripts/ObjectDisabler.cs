using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisabler : MonoBehaviour
{
    private GameObject _collisionObject;
    private Rigidbody _collisionObjectRb;

    // using OnCollisionEnter for now
    private void OnCollisionEnter(Collision collision)
    {
        _collisionObject = collision.gameObject;
        // if the collision object has an "Opponent" tag
        if (_collisionObject.CompareTag("Opponent"))
        {
            // if this GameObject has a "Boundary" tag
            /*if (gameObject.CompareTag("Boundary"))
            {*/
                _collisionObjectRb = _collisionObject.GetComponent<Rigidbody>();
                // disable the collision object
                _collisionObject.SetActive(false);
                // reset the rigidbody parameters
                _collisionObjectRb.velocity = Vector3.zero;
                _collisionObjectRb.isKinematic = true;
                // reset the position
                /*_collisionObject.transform.localPosition = ObjectSpawner.InitialTransform;
                _collisionObject.transform.rotation = ObjectSpawner.InitialRotation;*/
            /*}*/
        }
    }
}
