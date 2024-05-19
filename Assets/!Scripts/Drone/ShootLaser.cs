using _Drone.LaserObj;
using Config;
using System.Collections;
using UnityEngine;

namespace _Drone
{
    [AddComponentMenu("Scripts/_Drone/_Drone.ShootLaser")]
    internal class ShootLaser : MonoBehaviour
    {
        [SerializeField]
        private Camera playerCamera;

        [SerializeField]
        private Transform laserOrigin;

        [SerializeField]
        private KeyCode shootButton = KeyCode.Mouse0;

        [SerializeField]
        private float gunRange = 50f;

        [SerializeField]
        private GameObject laserPrefab;

        [SerializeField]
        private float laserTravelSpeed = 5f;

        [SerializeField]
        private float laserTravelRate = 1f;

        private bool beaming = false;
        private float laserEndRange = 1f;
        private GameObject laserObj;
        private LineRenderer laserRenderer;

        private void Update()
        {
            if (!Locker.instance.ShootingLocked)
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

        private void ProcessShooting()
        {

            if (!beaming)
            {
                _ = StartCoroutine(laserRangeRoutine());
                laserObj = Instantiate(laserPrefab);
                laserRenderer = laserObj.GetComponent<LineRenderer>();

                laserRenderer.SetPosition(1, laserOrigin.position);
                beaming = true;
            }
            laserRenderer.SetPosition(0, laserOrigin.position);
            laserObj.transform.position = transform.position;
            laserObj.transform.rotation = transform.rotation;

            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            laserRenderer.SetPosition(1, rayOrigin + (laserOrigin.transform.forward * laserEndRange));

            laserRenderer.enabled = true;
        }

        private IEnumerator laserRangeRoutine()
        {
            while (laserEndRange < gunRange)
            {
                yield return new WaitForSeconds(laserTravelRate);
                laserEndRange += laserTravelSpeed;
            }

        }

        private void StopShooting()
        {
            StopAllCoroutines();
            laserObj.GetComponent<LaserProjectile>().StopShooting(laserTravelRate, laserTravelSpeed);
            laserEndRange = 1f;
            beaming = false;
        }
    }
}
