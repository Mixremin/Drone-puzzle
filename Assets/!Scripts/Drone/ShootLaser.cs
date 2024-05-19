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
        private LineRenderer laserRenderer;

        [SerializeField]
        private float laserTravelSpeed = 5f;

        [SerializeField]
        private float laserTravelRate = 1f;

        private bool beaming = false;
        private float laserEndRange = 1f;

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
            laserRenderer.SetPosition(0, laserOrigin.position);
            if (!beaming)
            {
                _ = StartCoroutine(laserRangeRoutine());
                laserRenderer.SetPosition(1, laserOrigin.position);
                beaming = true;
            }

            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            //if (Physics.Raycast(rayOrigin, playerCamera.transform.forward, out RaycastHit hit, gunRange))
            //{
            //    laserRenderer.SetPosition(1, hit.point);
            //    Debug.Log(hit.transform.gameObject);
            //}
            //else
            //{

            laserRenderer.SetPosition(1, rayOrigin + (playerCamera.transform.forward * laserEndRange));
            //}

            laserRenderer.enabled = true;
        }

        private IEnumerator laserRangeRoutine()
        {
            while (laserEndRange < gunRange)
            {
                yield return new WaitForSeconds(laserTravelRate);

                laserEndRange += laserTravelSpeed;
                Debug.Log("New end Range:" + laserEndRange);
            }

        }

        private void StopShooting()
        {
            StopAllCoroutines();
            _ = StartCoroutine(laserTravelRoutine());
            laserEndRange = 1f;
            beaming = false;
        }

        private IEnumerator laserTravelRoutine()
        {

            while (laserRenderer.GetPosition(1) != (playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)) + (playerCamera.transform.forward * gunRange)))
            {
                yield return new WaitForSeconds(laserTravelRate);
                laserRenderer.SetPosition(0, laserRenderer.GetPosition(0) + (playerCamera.transform.forward * laserTravelSpeed));
                laserRenderer.SetPosition(1, laserRenderer.GetPosition(1) + (playerCamera.transform.forward * laserTravelSpeed));
            }

        }
    }
}
