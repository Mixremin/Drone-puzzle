using _Drone.LaserObj;
using _LevelSpecific;
using Config;
using System.Collections;
using UnityEngine;

namespace _Drone
{
    [AddComponentMenu("Scripts/_Drone/_Drone.ShootLaser")]
    internal class ShootLaser : MonoBehaviour
    {
        [Header("Laser Objects")]
        [SerializeField]
        private Camera playerCam;

        [SerializeField]
        private Transform laserOrigin;

        [SerializeField]
        private Vector3 originOffset;

        [SerializeField]
        private GameObject laserPrefab;

        [Header("Parameters")]
        [SerializeField]
        private float maxLaserRange = 10f;

        [SerializeField]
        private float laserTravelSpeed = 5f;

        [SerializeField]
        private float laserTravelRate = 1f;

        [SerializeField]
        private float collisionRangeOffset = 0.1f;

        [Header("Controls")]
        [SerializeField]
        private KeyCode shootButton = KeyCode.Mouse0;

        private bool beaming = false;
        private float laserEndRange = 1f;
        private GameObject laserObj;
        private LineRenderer laserRenderer;
        private bool laserImpacting = false;
        private bool canLaserGrow = true;

        private void Update()
        {
            if (!Locker.instance.ShootingLocked)
            {
                if (!Locker.instance.LockedByMenu)
                {
                    if (Input.GetKey(shootButton))
                    {
                        ProcessShooting();
                    }
                    if (Input.GetKeyUp(shootButton))
                    {
                        StopShooting();
                    }
                }
            }
        }

        private void ProcessShooting()
        {
            if (!beaming)
            {
                _ = StartCoroutine(laserRangeRoutine());
                laserObj = Instantiate(laserPrefab);
                laserRenderer = laserObj.GetComponent<LineRenderer>();

                laserRenderer.SetPosition(1, laserOrigin.position + originOffset);
                beaming = true;
                laserRenderer.enabled = true;

            }
            laserRenderer.SetPosition(0, laserOrigin.position + originOffset);
            Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            float lineMagnitude = (laserRenderer.GetPosition(1) - laserRenderer.GetPosition(0)).magnitude;
            Vector3 lineDirection = laserRenderer.GetPosition(1) - laserRenderer.GetPosition(0);


            if (Physics.Raycast(laserRenderer.GetPosition(0), lineDirection, out RaycastHit hit, lineMagnitude))
            {
                canLaserGrow = false;

                float newLaserMagnitude = (hit.point - laserRenderer.GetPosition(0)).magnitude;
                if (laserEndRange - newLaserMagnitude > collisionRangeOffset)
                {
                    laserEndRange = newLaserMagnitude;
                }

                if (!laserImpacting)
                {
                    _ = StartCoroutine(laserImpactRoutine(hit));
                }
            }
            else
            {
                canLaserGrow = true;
            }
            laserRenderer.SetPosition(1, rayOrigin + (laserOrigin.transform.forward * laserEndRange));
        }

        private IEnumerator laserRangeRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(laserTravelRate);
                if (canLaserGrow && laserEndRange < maxLaserRange)
                {
                    laserEndRange += laserTravelSpeed;
                }
            }

        }

        private IEnumerator laserImpactRoutine(RaycastHit hit)
        {

            laserImpacting = true;
            yield return new WaitForSeconds(0.1f);
            Debug.Log(hit.transform);
            if (hit.transform.TryGetComponent<IEnemy>(out IEnemy enemy))
            {
                enemy.TakeTick();
                Debug.Log("Enemy Damaged(Need more smart system)");
            }

            laserImpacting = false;
        }

        public void StopShooting()
        {
            if (laserObj != null)
            {
                StopAllCoroutines();
                laserObj.transform.position = transform.position;
                laserObj.transform.rotation = transform.rotation;
                laserObj.GetComponent<LaserProjectile>().StopShooting(laserTravelRate, laserTravelSpeed);
                laserEndRange = 1f;
                beaming = false;
                laserImpacting = false;
            }
        }
    }
}
