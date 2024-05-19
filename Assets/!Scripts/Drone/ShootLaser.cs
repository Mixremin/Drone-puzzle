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
        private bool shootFromCamera = true;

        [SerializeField]
        private Camera playerCam;

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
        private bool laserImpacting = false;

        private void Awake()
        {
            if (shootFromCamera)
            {
                laserOrigin = playerCam.transform;
            }
        }

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
                laserRenderer.enabled = true;
            }
            laserRenderer.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            float lineMagnitude = (laserRenderer.GetPosition(1) - laserRenderer.GetPosition(0)).magnitude;
            Vector3 lineDirection = laserRenderer.GetPosition(1) - laserRenderer.GetPosition(0);

            if (Physics.Raycast(laserRenderer.GetPosition(0), lineDirection, out RaycastHit hit, lineMagnitude))
            {
                laserRenderer.SetPosition(1, hit.point);
                if (!laserImpacting)
                {
                    _ = StartCoroutine(laserImpactRoutine(hit));
                }
            }
            else
            {
                laserRenderer.SetPosition(1, rayOrigin + (laserOrigin.transform.forward * laserEndRange));
            }
        }

        private IEnumerator laserRangeRoutine()
        {
            while (laserEndRange < gunRange)
            {
                yield return new WaitForSeconds(laserTravelRate);
                laserEndRange += laserTravelSpeed;
            }

        }

        private IEnumerator laserImpactRoutine(RaycastHit hit)
        {
            laserImpacting = true;
            yield return new WaitForSeconds(0.1f);

            Debug.Log(hit.transform.gameObject);
            laserImpacting = false;
        }

        private void StopShooting()
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
