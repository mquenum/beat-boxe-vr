using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dependency on Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class ObjectController : MonoBehaviour
{
    [SerializeField] private float _force = 1.0f;
    private Rigidbody _rb;
    private bool _isActive = false;

    void OnEnable()
    {
        if (_isActive)
        {
            _rb = gameObject.GetComponent<Rigidbody>();
            _rb.isKinematic = false;
            StartCoroutine(MoveForward(_rb));
        }
        else
        {
            _isActive = true;
        }
    }

    IEnumerator MoveForward(Rigidbody rb)
    {
        while (true)
        {
            rb.AddForce(0, 0, _force*-1);
            yield return null;
        }
    }
}
