using Player;
using UnityEngine;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.Laser")]
    internal class Laser : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer lineRenderer;

        private Transform leftChild;
        private Transform rightChild;

        private void Start()
        {
            leftChild = transform.GetChild(0);
            rightChild = transform.GetChild(1);

            lineRenderer.SetPosition(0, leftChild.position);
            lineRenderer.SetPosition(1, rightChild.position);

            lineRenderer.enabled = true;
        }
        private void OnTriggerEnter(Collider collision)
        {
            Debug.Log(collision.gameObject);
            if (collision.gameObject.TryGetComponent<FirstPersonMovement>(out _))
            {
                Debug.Log("Player touched laser");
            }
        }
    }
}
