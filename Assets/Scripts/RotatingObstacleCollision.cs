using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacleCollision : MonoBehaviour
{
    private GameObject _spawnerGO;

    private void Start()
    {
        _spawnerGO = GameObject.FindGameObjectWithTag("Spawner");
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

                if (spawner != null)
                {
                    spawner.ResetObj(gameObject);
                }
            }
        }
    }
}
