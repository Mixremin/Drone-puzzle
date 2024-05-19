using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

    // Update is called once per frame
    private void Update()
    {
        DestroyRoad();
    }

    private void FixedUpdate()
    {

        Move();

    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void Move()
    {

        transform.Translate(-transform.forward * _speed * Time.fixedDeltaTime);

    }

    private void DestroyRoad()
    {

        if (transform.position.z < -30)
        {
            Destroy(gameObject);
        }
    }

}
