using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class LayerName : MonoBehaviour
{
    public static LayerName SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }

    public string GetLayerName(int layerIndex)
    {
        Debug.Log(layerIndex);
        return LayerMask.LayerToName(layerIndex);
    }
}
