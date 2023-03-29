using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PunchManager : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private PlayerCounterManager _playerCounter;
    [SerializeField] private XRInteractorLineVisual _handInteractorLineVisual;
    private Vector3 _previousPosition;
    private ScoreManager _scoreManager;
    public float DistanceToCenter;
    public static PunchManager SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _scoreManager = ScoreManager.SharedInstance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;
        string layerName = LayerMask.LayerToName(layer);

        if (layerName == "Opponent")
        {
            GetDistanceToCenter(collision);
        }
    }

    /*private void TypeInducedBehaviour(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Punch":
                Transform hitZone = collision.gameObject.transform.GetChild(1);

                if (Vector3.Angle(transform.position - _previousPosition, hitZone.up) > 70)
                {
                    if (GetDistanceToCenter(collision) < 5.0f)
                    {
                        Debug.Log("You punch real good !");
                        _spawner.ResetObj(collision.gameObject);
                    }
                    else
                    {
                        Debug.Log("You punch good !");
                    }
                    _spawner.ResetObj(collision.gameObject);
                }
                _previousPosition = transform.position;
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
    }*/

    public float GetDistanceToCenter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Vector3 center = collision.transform.position;
        Vector3 point = contact.point;
        DistanceToCenter = Vector3.Distance(center, point);

        //Debug.Log(DistanceToCenter);

        return DistanceToCenter;

        //Debug.Log("Distance: " + DistanceToCenter);
    }
}
