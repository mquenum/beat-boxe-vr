using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjOnCollision : MonoBehaviour
{
    private ObjectSpawner _spawner;

    private void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;
        // Get the layer name from the layer mask
        string layerName = LayerMask.LayerToName(layer);
        if (layerName == "Opponent")
        {
            DisableObj(collision.gameObject);
        }
    }

    public void DisableObj(GameObject obj)
    {
        _spawner.ResetObj(obj);
    }
}
