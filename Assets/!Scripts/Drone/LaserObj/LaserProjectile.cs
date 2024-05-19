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
            //TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
            int iter = 0;
            while (iter < 6)
            {
                yield return new WaitForSeconds(laserTravelRate);
                iter++;

                float lineMagnitude = (laserRenderer.GetPosition(1) - laserRenderer.GetPosition(0)).magnitude;

                if (Physics.Raycast(laserRenderer.GetPosition(0), transform.forward, out RaycastHit hit, lineMagnitude))
                {
                    Debug.Log(hit.transform.gameObject);
                    Destroy(gameObject);
                    break;
                }
                else
                {
                    laserRenderer.SetPosition(0, laserRenderer.GetPosition(0) + (transform.forward * laserTravelSpeed));
                    laserRenderer.SetPosition(1, laserRenderer.GetPosition(1) + (transform.forward * laserTravelSpeed));
                }
            }
            Destroy(gameObject);
        }
    }
}
