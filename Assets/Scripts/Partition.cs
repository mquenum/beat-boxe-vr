using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Partition : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _BPM;
    [SerializeField] private List<Transform> _lanes;
    private float _beat;
    private float _timer;
    private int _count = 0;
    private Pooler _directPunchesPool;
    private Pooler _sidePunchesPool;
    private Pooler _countersPool;
    private Pooler _dodgesPool;

    // Start is called before the first frame update
    void Start()
    {
        _beat = (60 / _BPM) * 2;
        _directPunchesPool = _spawner.Poolers[0];
        _sidePunchesPool = _spawner.Poolers[1];
        _countersPool = _spawner.Poolers[2];
        _dodgesPool = _spawner.Poolers[3];
    }

    private int RandomRotation(int val1, int val2)
    {
        return val1 * val2;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > _beat)
        {
            int rotationVal;
            /*switch (_count)
            {
                case 0:
                    _spawner.Spawn(_lanes[Random.Range(0, 3)], _directPunchesPool.Pool, Quaternion.Euler(270, 0, 0));
                    break;
                case 1:
                    rotationVal = RandomRotation(Random.Range(1, 4), 90);
                    _spawner.Spawn(_lanes[Random.Range(0, 3)], _sidePunchesPool.Pool, Quaternion.Euler(0, 0, rotationVal));
                    break;
                case 2:
                    rotationVal = RandomRotation(Random.Range(-1, 1), 45);
                    _spawner.Spawn(_lanes[1], _dodgesPool.Pool, Quaternion.Euler(0, 0, rotationVal));
                    break;
                case 3:
                    _spawner.Spawn(_lanes[1], _countersPool.Pool, Quaternion.Euler(0, 0, 0));
                    break;
            }
            if (_count < 3) { _count++; } else { _count = 0; };*/

            rotationVal = RandomRotation(Random.Range(1, 4), 90);
            _spawner.Spawn(_lanes[Random.Range(0, 3)], _sidePunchesPool.Pool, Quaternion.Euler(0, 0, rotationVal));

            _timer -= _beat;
        }

        _timer += Time.deltaTime;
    }
}
