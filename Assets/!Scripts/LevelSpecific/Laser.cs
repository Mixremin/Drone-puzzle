using _Player;
using Player;
using UnityEngine;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.Laser")]
    internal class Laser : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer lineRenderer;

        [SerializeField]
        private float damage = 50f;

        private Transform leftChild;
        private Transform rightChild;

        private new bool collider = false;
        private bool playerDamaged = false;



        private void Start()
        {
            leftChild = transform.GetChild(0);
            rightChild = transform.GetChild(1);
        }

        private void Update()
        {
            lineRenderer.SetPosition(0, leftChild.position);
            lineRenderer.SetPosition(1, rightChild.position);

            if (!collider)
            {
                lineRenderer.enabled = true;
                collider = true;
            }
        }

        private void FixedUpdate()
        {
            float lineMagnitude = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).magnitude;
            Vector3 lineDirection = lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0);
            if (Physics.Raycast(lineRenderer.GetPosition(0), lineDirection, out RaycastHit hit, lineMagnitude))
            {
                if (hit.transform.TryGetComponent(out FirstPersonMovement playerScript) && !playerDamaged)
                {
                    playerDamaged = true;
                    playerScript.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
                }
                else if (!hit.transform.TryGetComponent(out FirstPersonMovement _))
                {
                    playerDamaged = false;
                }
            }
        }
        //private void OnTriggerEnter(Collider collision)
        //{
        //    Debug.Log(collision.gameObject);
        //    if (collision.gameObject.TryGetComponent<FirstPersonMovement>(out _))
        //    {
        //        collision.GetComponent<PlayerStats>().TakeDamage(damage);
        //        Debug.Log("Player touched laser");
        //    }
        //}
    }
}
