using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependency on Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class ObjectController : MonoBehaviour
{
    [SerializeField] private float _force = 10.0f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
    }

    void OnEnable()
    {
        Debug.Log(gameObject.CompareTag("RotatingOpponent"));
        // random rotation of GameObject 
        if (gameObject.CompareTag("RotatingOpponent"))
        {
            gameObject.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
        }
    }

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            // set isKinematic to false and push the rigidBody forward
            _rb.isKinematic = false;
            _rb.AddForce(transform.forward * _force);
        }
    }
}
