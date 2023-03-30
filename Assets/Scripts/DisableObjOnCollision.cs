using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjOnCollision : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    private ScoreManager _score;

    private void Start()
    {
        _score = ScoreManager.SharedInstance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        int layer = collision.gameObject.layer;
        // Get the layer name from the layer mask
        string layerName = LayerMask.LayerToName(layer);

        if (layerName == "Opponent")
        {
            _score.ScoreDown(1);
            _spawner.ResetObj(collision.gameObject);
        }
    }
}
