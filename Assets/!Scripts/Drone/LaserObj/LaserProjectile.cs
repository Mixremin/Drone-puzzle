using _LevelSpecific;
using System.Collections;
using UnityEngine;

namespace _Drone.LaserObj
{
    [AddComponentMenu("Scripts/_Drone/LaserObj/_Drone.LaserObj.LaserProjectile")]
    internal class LaserProjectile : MonoBehaviour
    {
        [SerializeField]
        private float lifeTime = 3f;

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
            float timer = 0f;
            while (timer < lifeTime)
            {
                timer += Time.deltaTime;
                yield return new WaitForSeconds(laserTravelRate);

                float lineMagnitude = (laserRenderer.GetPosition(1) - laserRenderer.GetPosition(0)).magnitude;
                if (Physics.Raycast(laserRenderer.GetPosition(0), transform.forward, out RaycastHit hit, lineMagnitude))
                {
                    if (hit.transform.TryGetComponent<IEnemy>(out IEnemy enemy))
                    {
                        enemy.TakeTick();
                        Debug.Log("Enemy Damaged(Need more smart system)");
                        Destroy(gameObject);
                    }
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
