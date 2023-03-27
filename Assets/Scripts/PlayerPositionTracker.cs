using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionTracker : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    public static PlayerPositionTracker SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    public Vector3 GetHeadsetPosition()
    {
        return _camera.transform.position;
    }
}
