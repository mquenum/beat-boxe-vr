using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour
{
    [SerializeField] SoundClipManager _soundClipManager;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] List<GameObject> _collisionObjects;
    private CollisionManager _collisionManager;

    private void Start()
    {
        _collisionManager = CollisionManager.SharedInstance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject hands in _collisionObjects)
        {
            Debug.Log(collision.GetContact(0));

            if (_collisionManager.DistanceToCenter <= 0.1)
            {
                _audioSource.clip = _soundClipManager._audioClips[1];
            }
            else
            {
                _audioSource.clip = _soundClipManager._audioClips[0];
            }

            _audioSource.Play();
        }
    }
}
