using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PunchManager : MonoBehaviour
{
    /*private ScoreManager _scoreManager;*/
    public float DistanceToCenter;
    //public static PunchManager SharedInstance;

    /*private void Awake()
    {
        SharedInstance = this;
    }*/

    private void Start()
    {
        /*_scoreManager = ScoreManager.SharedInstance;*/
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

    public float GetDistanceToCenter(Collision collision)
    {
        ContactPoint contact = collision.GetContact(0);
        Vector3 center = collision.transform.position;
        Vector3 point = contact.point;
        DistanceToCenter = Vector3.Distance(center, point);

        Debug.Log(DistanceToCenter);

        return DistanceToCenter;
    }
}
