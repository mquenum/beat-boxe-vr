using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    [SerializeField] PlayerSoundManager _punchSounds;
    [SerializeField] AudioSource _playerAS;
    private ObjectDisabler _collisionManager;

    private void Start()
    {
        _collisionManager = ObjectDisabler.SharedInstance;
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.GetContact(0));

        if (_collisionManager.DistanceToCenter <= 0.1)
        {
            _playerAS.clip = _punchSounds._punchSoundsClips[1];
        }
        else
        {
            _playerAS.clip = _punchSounds._punchSoundsClips[0];
        }

        _playerAS.Play();
    }

}
