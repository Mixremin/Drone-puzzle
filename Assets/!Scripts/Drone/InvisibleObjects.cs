using UnityEngine;

namespace _Drone
{
    [AddComponentMenu("Scripts/_Drone/_Drone.InvisibleObjects")]
    internal class InvisibleObjects : MonoBehaviour
    {
        [SerializeField]
        private Camera cam;

        [SerializeField]
        private LayerMask showLayersInDrone;

        private LayerMask oldCulling;

        private void OnEnable()
        {
            ChangeCullingMask();
        }
        public void ChangeCullingMask()
        {
            oldCulling = cam.cullingMask;
            cam.cullingMask = showLayersInDrone;
        }

        public void ReturnCullingMask()
        {
            cam.cullingMask = oldCulling;
        }

        private void OnDisable()
        {
            ReturnCullingMask();
        }
    }
}
