using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    private ScoreManager _score;
    private GameObject _spawnerGO;
    private PlayerCounterManager _playerHandsPosition;
    private GameObject _objAudioManager;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _playerHandsPosition = PlayerCounterManager.SharedInstance;
        _spawnerGO = GameObject.FindGameObjectWithTag("Spawner");
        _objAudioManager = GameObject.FindGameObjectWithTag("AudioClips");
        _audioSource = _objAudioManager.GetComponent<AudioSource>();
        _score = ScoreManager.SharedInstance;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (_playerHandsPosition)
        {
            Spawner spawner = _spawnerGO.GetComponent<Spawner>();
            SoundClipManager clips = _objAudioManager.GetComponent<SoundClipManager>();

            _audioSource.clip = clips._audioClips[2];
            _audioSource.Play();
            _score.ScoreUp(1);
            spawner.ResetObj(gameObject);
        }
    }
}
