using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour
{
    [SerializeField] SoundClipManager _soundClipManager;
    [SerializeField] AudioSource _audioSource;
    private PunchManager _collisionManager;

    private void Start()
    {
        //_collisionManager = PunchManager.SharedInstance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (_collisionManager.DistanceToCenter <= 0.1)
        {
            _audioSource.clip = _soundClipManager._audioClips[1];
        }
        else
        {
            _audioSource.clip = _soundClipManager._audioClips[0];
        }

        _audioSource.Play();*/
    }
}
