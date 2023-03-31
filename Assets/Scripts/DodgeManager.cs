using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeManager : MonoBehaviour
{
    private ScoreManager _score;
    private GameObject _spawnerGO;
    private GameObject _objAudioManager;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _spawnerGO = GameObject.FindGameObjectWithTag("Spawner");
        _objAudioManager = GameObject.FindGameObjectWithTag("AudioClips");
        _audioSource = _objAudioManager.GetComponent<AudioSource>();
        _score = ScoreManager.SharedInstance;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Spawner spawner = _spawnerGO.GetComponent<Spawner>();
            SoundClipManager clips = _objAudioManager.GetComponent<SoundClipManager>();
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;

            _audioSource.clip = clips._audioClips[2];
            _audioSource.Play();
            _score.ScoreDown(1, 2);
            spawner.ResetObj(gameObject);
        }
    }
}
