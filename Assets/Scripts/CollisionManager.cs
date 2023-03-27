using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private ObjectSpawner _spawner;
    private PlayerPositionManager _playerPosition;
    public float DistanceToCenter;
    public static CollisionManager SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _spawner = ObjectSpawner.SharedInstance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;
        // Get the layer name from the layer mask
        string layerName = LayerMask.LayerToName(layer);

        // Print the layer name to the console
        Debug.Log("Layer name: " + layerName);

        if (layerName == "Opponent")
        {
            TypeInducedBehaviour(collision.gameObject);
            GetDistanceToCenter(collision);
            _spawner.ResetObj(collision.gameObject);
        }
    }

    private void TypeInducedBehaviour(GameObject collision)
    {
        string tag = collision.gameObject.tag;

        switch (tag)
        {
            case "Punch":
                Debug.Log("You punch !");
                break;
            case "Dodge":
                float distanceBetweenPoints = Vector3.Distance(_playerPosition.GetHeadsetPosition(), collision.transform.position);

                Debug.Log(distanceBetweenPoints);
                
                if (distanceBetweenPoints >= 1.0f)
                {
                    _playerPosition.GetHeadsetPosition();
                }
                break;
            case "Counter":
                if (_playerPosition._hasCounterPosition)
                {
                    Debug.Log("Counter !");
                }
                else
                {
                    Debug.Log("You didn't counter !");
                }
                break;
        }
    }

    private void GetDistanceToCenter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Vector3 center = collision.transform.position;
        Vector3 point = contact.point;
        DistanceToCenter = Vector3.Distance(center, point);

        //Debug.Log("Distance: " + DistanceToCenter);
    }
}
