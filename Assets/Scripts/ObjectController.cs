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
    private GameObject _spawnerGO;
    private string _objectTag;
    private AudioSource _audioSource;
    private GameObject _objAudioManager;
    private Vector3 _size;

    void OnEnable()
    {
        if (_isActive)
        {
            _objectTag = gameObject.transform.tag;
            _objAudioManager = GameObject.FindGameObjectWithTag("AudioClips");
            _audioSource = _objAudioManager.GetComponent<AudioSource>();
            _size = GetComponent<BoxCollider>().size;
            _rb = gameObject.GetComponent<Rigidbody>();
            _rb.isKinematic = false;
            StartCoroutine(MoveForward());
            _spawnerGO = GameObject.FindGameObjectWithTag("Spawner");
        }
        else
        {
            _isActive = true;
        }
    }

    IEnumerator MoveForward()
    {
        while (true)
        {
            Vector3 movement = -Vector3.forward * _force * Time.deltaTime;
            _rb.MovePosition(transform.position + movement);

            yield return null;
        }
    }
}
