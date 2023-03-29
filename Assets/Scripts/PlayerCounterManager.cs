using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerCounterManager : MonoBehaviour
{
    [SerializeField] private GameObject _rightHand;
    public bool _hasCounterPosition = false;
    public static PlayerCounterManager SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
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
        