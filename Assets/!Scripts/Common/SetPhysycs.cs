using UnityEngine;

namespace _Common
{
    [AddComponentMenu("Scripts/_Common/_Common.SetPhysycs")]
    internal class SetPhysycs : MonoBehaviour
    {
        [SerializeField]
        private Vector3 newGravity;

        private void Start()
        {
            Physics.gravity = newGravity;
        }
    }
}
