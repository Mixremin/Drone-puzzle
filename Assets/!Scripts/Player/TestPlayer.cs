using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{

    [SerializeField] private RoadSpawner _roadSrawner;

    private void OnTriggerEnter(Collider other)
    {
        _roadSrawner.Spawn();
    }

}
