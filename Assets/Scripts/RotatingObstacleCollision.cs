using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacleCollision : MonoBehaviour
{
    private ScoreManager _score;
    private GameObject _spawnerGO;
    private AudioSource _audioSource;
    private GameObject _objAudioManager;
    private Vector3 _size;

    private void Start()
    {
        _spawnerGO = GameObject.FindGameObjectWithTag("Spawner");
        _objAudioManager = GameObject.FindGameObjectWithTag("AudioClips");
        _audioSource = _objAudioManager.GetComponent<AudioSource>();
        _size = GetComponent<BoxCollider>().size;
        _score = ScoreManager.SharedInstance;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision was with the XR Rig
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            // Convert the point of collision from world space to local space of the cube
            Vector3 localPoint = transform.InverseTransformPoint(collisionPoint);

            // Determine which face of the cube was hit based on the local point of collision
            if (localPoint.y > 0.5f) // Top face
            {
                // Vector3 collisionNormal = transform.up;
                Spawner spawner = _spawnerGO.GetComponent<Spawner>();
                SoundClipManager clips = _objAudioManager.GetComponent<SoundClipManager>();
                if (spawner != null)
                {
                    Vector3 center = transform.TransformPoint(new Vector3(0f, 0.75f, 0f)); // Center of top face
                    float distance = Vector3.Distance(center, collisionPoint);

                    // set audioclip to play relative to distance from center
                    if (distance < 0.1)
                    {
                        _audioSource.clip = clips._audioClips[1];
                        _score.ScoreUp(2);
                    }
                    else
                    {
                        _audioSource.clip = clips._audioClips[0];
                        _score.ScoreUp(1);
                    }

                    _audioSource.Play();
                    spawner.ResetObj(gameObject);
                }
            }
        }
    }
}
