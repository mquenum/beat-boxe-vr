using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private ObjectSpawner _spawner;
    private PlayerCounterManager _playerCounter;
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

        if (layerName == "Opponent")
        {
            TypeInducedBehaviour(collision.gameObject);
            GetDistanceToCenter(collision);
            _spawner.ResetObj(collision.gameObject);
        }
    }

    private void TypeInducedBehaviour(GameObject collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Punch":
                Debug.Log("You punch !");
                break;
            case "Dodge":
                Debug.Log("Didn't dodge");
                break;
            case "Counter":
                if (_playerCounter._hasCounterPosition)
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
