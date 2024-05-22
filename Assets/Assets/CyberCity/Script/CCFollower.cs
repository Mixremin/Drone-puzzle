//CyberCity script for demo

using UnityEngine;

public class CCFollower : MonoBehaviour
{
    public float SpeedMove = 1.1f;
    public float SpeedLook = 1.0f;
    public float StopDistance = 2.0f;
    public GameObject Player;
    private bool DontMove;

    private void Start()
    {
        Player = GameObject.Find("Player");

    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        //lookat
        Vector3 localTarget = transform.InverseTransformPoint(Player.transform.position);
        float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
        Vector3 eulerAngleVelocity = new(0, angle, 0);
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime * SpeedLook);
        GetComponent<Rigidbody>().MoveRotation(GetComponent<Rigidbody>().rotation * deltaRotation);

        //move
        Vector3 futur_pos = transform.TransformDirection(new Vector3(0, 0, SpeedMove * Time.deltaTime));
        Vector3 step_pos = transform.position + futur_pos;
        if (!DontMove)
        {
            GetComponent<Rigidbody>().MovePosition(step_pos);
        }

        if (Player != null)
        {
            //stop
            if (Vector3.Distance(Player.transform.position, transform.position) < StopDistance)
            {
                DontMove = true;
            }
            else
            {
                DontMove = false;
            }
        }
    }
}
