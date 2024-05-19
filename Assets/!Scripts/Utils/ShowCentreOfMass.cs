using UnityEngine;

namespace _Utils
{
    [AddComponentMenu("Scripts/_Utils/_Utils.ShowCentreOfMass")]
    internal class ShowCentreOfMass : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rb;

        private Vector3 centreOfMass;

        private void Awake()
        {
            centreOfMass = rb.centerOfMass;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(rb.transform.position + (rb.transform.rotation * centreOfMass), 0.1f);
        }
    }
}
