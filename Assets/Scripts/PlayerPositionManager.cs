using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerPositionManager : MonoBehaviour
{
    [SerializeField] private GameObject _rightHand;
    public bool _hasCounterPosition = false;
    public Vector3 _headsetPosition;
    public static PlayerPositionManager SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    public Vector3 GetHeadsetPosition()
    {
        return InputTracking.GetLocalPosition(XRNode.Head);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _rightHand)
        {
            _hasCounterPosition = true;
            Debug.Log("Counter !");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _rightHand)
        {
            _hasCounterPosition = false;
            Debug.Log("No counter !");
        }
    }

}
