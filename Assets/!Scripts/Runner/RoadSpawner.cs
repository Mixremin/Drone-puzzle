using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> _roads;
    [SerializeField] private float _roadLength = 20;
    private GameObject _road;

    // Start is called before the first frame update
    void Start()
    {

        _road = Instantiate(_roads[Random.Range(0, _roads.Count - 1)], transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void Spawn()
    {

        Vector3 position = new Vector3(0, 0, _road.transform.position.z + _roadLength);
        _road = Instantiate(_roads[Random.Range(0, _roads.Count - 1)], position, Quaternion.identity);

    }

}
