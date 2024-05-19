using System.Collections;
using UnityEngine;

namespace _Drone.LaserObj
{
    [AddComponentMenu("Scripts/_Drone/LaserObj/_Drone.LaserObj.LaserProjectile")]
    internal class LaserProjectile : MonoBehaviour
    {
        private LineRenderer laserRenderer;

        private void Awake()
        {
            laserRenderer = GetComponent<LineRenderer>();
        }
        public void StopShooting(float laserTravelRate, float laserTravelSpeed)
        {
            _ = StartCoroutine(laserTravelRoutine(laserTravelRate, laserTravelSpeed));
        }

        private IEnumerator laserTravelRoutine(float laserTravelRate, float laserTravelSpeed)
        {
            int iter = 0;
            while (iter < 6)
            {
                yield return new WaitForSeconds(laserTravelRate);
                iter++;


                laserRenderer.SetPosition(0, laserRenderer.GetPosition(0) + (transform.forward * laserTravelSpeed));
                laserRenderer.SetPosition(1, laserRenderer.GetPosition(1) + (transform.forward * laserTravelSpeed));
            }
            Destroy(gameObject);
        }
    }
}
