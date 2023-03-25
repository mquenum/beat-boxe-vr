using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObjectPartition : MonoBehaviour
{
    [SerializeField] private float _BPM;
    [SerializeField] private List<Transform> _lanes;
    private float _beat;
    private float _timer;
    private ObjectSpawner _spawner;
    private ObjectPooler _pools;

    private void Start()
    {
        _beat = (60 / _BPM) * 2;
        _spawner = ObjectSpawner.SharedInstance;
        _pools = ObjectPooler.SharedInstance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _beat)
        {
            _spawner.Spawn(_lanes[Random.Range(0,3)], _pools.PooledObstaclesDirect, Quaternion.Euler(0, 0, 0));
            _timer -= _beat;
        }

        _timer += Time.deltaTime;
    }
}
