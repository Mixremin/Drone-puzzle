using UnityEngine;
namespace Drone
{
    internal class DroneUpAndDown : MonoBehaviour
    {
        [SerializeField]
        private new GameObject camera;

        private void Update()
        {
            transform.localRotation = camera.transform.localRotation;
        }
    }
}
