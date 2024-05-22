using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> _roads;
    [SerializeField] private float _roadLength = 20;
    [SerializeField] private float roadSpeed = 5f;
    private GameObject _road;

    // Start is called before the first frame update
    private void Start()
    {

        _road = Instantiate(_roads[Random.Range(0, _roads.Count - 1)], transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    private void Update()
    {

    }



    public void Spawn()
    {
        Debug.Log("new road spawned");
        Vector3 position = new(0, 0, _road.transform.position.z + _roadLength);
        _road = Instantiate(_roads[Random.Range(0, _roads.Count - 1)], position, Quaternion.identity);
        _road.GetComponent<Road>().SetSpeed(roadSpeed);
    }

}
