using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectToSpawn;
    [SerializeField] private int _amountToSpawn;
    [SerializeField] private List<Transform> _lanes;
    /*[Range(60, 255)]
    [SerializeField] private int _bpm = 120;*/
    private List<GameObject> _pool;
    private float _timer = 0;
    private int _maxLaneNb;
    /*private float _beat;*/

    private void Awake()
    {
        // instatiate here
        /*_beat = (60 / _bpm) * 2;*/
        _maxLaneNb = _lanes.Count;
        int _selectLane = Random.Range(0, _maxLaneNb);

        // get the pool from the ObjectPooler
        // create multiple pools each for every object
        _pool = ObjectPooler.SharedInstance.PooledObjects;

        for (int i = 0; i < _amountToSpawn; i++)
        {
            foreach (GameObject spawnedObj in _objectToSpawn)
            {
                // instantiate object in variable
                GameObject obj = Instantiate(spawnedObj, _lanes[_selectLane].transform.position, _lanes[_selectLane].transform.rotation);

                obj.transform.SetParent(transform);

                // deactivate object
                obj.SetActive(false);
                // add object to the pool
                _pool.Add(obj);
            }
        }

        ActivatePooledObj();
    }

    void Start()
    {
        
    }

    private void Update()
    {

        if (_timer > 5.0f)
        {
            ActivatePooledObj();
            // _timer -= _beat;
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    // function to activate an object from the pool
    public void ActivatePooledObj()
    {
        // get the first inactive GameObject in the pool
        GameObject obj = ObjectPooler.SharedInstance.GetPooledObject();

        // if there is any inactive GameObject in the pool
        if (obj != null)
        {
            int getLaneNb = ReturnLane(_maxLaneNb);
            // 
            obj.transform.position = _lanes[getLaneNb].transform.position;
            // activate that game object
            obj.SetActive(true);
        }
    }

    private int ReturnLane(int maxLaneNb)
    {
        return Random.Range(0, maxLaneNb);
    }
}
