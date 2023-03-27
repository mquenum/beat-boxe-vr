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


    private List<GameObject> GetRandomPool(int index)
    {
        switch (index)
        {
            case 0:
                return _pools.PooledObstacles;
            case 1:
                return _pools.PooledObstaclesDirect;
            case 2:
                return _pools.PooledDodges;
            case 3:
                return _pools.PooledCounter;
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _beat)
        {
            /*_spawner.Spawn(_lanes[Random.Range(0, 3)], GetRandomPool(Random.Range(0, 4)), Quaternion.Euler(0, 0, 0));*/
            _spawner.Spawn(_lanes[1], _pools.PooledDodges, Quaternion.Euler(0, 0, 0));
            _timer -= _beat;
        }

        _timer += Time.deltaTime;
    }
}
