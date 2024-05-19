using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{

    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {
        DestroyRoad();
    }

    private void FixedUpdate()
    {

        Move();

    }

    private void Move()
    {

        transform.Translate(-transform.forward * _speed * Time.fixedDeltaTime);

    }

    private void DestroyRoad()
    {

        if (transform.position.z < -30)
            Destroy(gameObject);

    }

}
