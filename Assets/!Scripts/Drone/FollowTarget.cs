using UnityEngine;

namespace _Drone
{
    [AddComponentMenu("Scripts/_Drone/_Drone.FollowPlayer")]
    internal class FollowTarget : MonoBehaviour
    {
        [SerializeField]
        private Transform target;

        private void Update()
        {
            transform.position = target.position;
        }
    }
}
