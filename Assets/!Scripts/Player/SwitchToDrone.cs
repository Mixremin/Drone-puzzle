using _Drone;
using Config;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
    internal class SwitchToDrone : MonoBehaviour
    {
        [Required]
        [SerializeField]
        private GameObject playerCam;

        [Required]
        [SerializeField]
        private GameObject droneCam;

        [SerializeField]
        private string invisibleLayerName;

        [SerializeField]
        private List<GameObject> notRenderInFps;

        [SerializeField]
        private FirstPersonMovement fpMovement;

        [SerializeField]
        private ShootLaser shootLaser;

        [SerializeField]
        private float timeSlow = 3f;

        [SerializeField]
        private GameObject droneReticle;

        [SerializeField]
        private GameObject playerReticle;

        public KeyCode SwitchKey = KeyCode.F;

        private bool isDroning = false;
        // Start is called before the first frame update

        // Update is called once per frame

        private void Awake()
        {
            HideInFPS();
        }
        private void Update()
        {
            if (Input.GetKeyUp(SwitchKey))
            {
                if (!isDroning)
                {
                    SwitchToDroning();
                }
                else
                {
                    SwitchToFPS();
                }
            }
        }

        public void SwitchToDroning()
        {
            Time.timeScale = 1 / timeSlow;

            playerCam.SetActive(false);
            ShowInTPS();
            droneCam.SetActive(true);

            Locker.instance.InDroneLock();
            fpMovement.ResetVelocity();

            isDroning = true;

        }

        public void SwitchToFPS()
        {
            shootLaser.StopShooting();

            Time.timeScale = 1f;

            droneCam.SetActive(false);
            HideInFPS();

            playerCam.SetActive(true);

            Locker.instance.InFPSLock();

            isDroning = false;
        }

        private void HideInFPS()
        {
            playerReticle.SetActive(true);
            droneReticle.SetActive(false);
            foreach (GameObject notRendered in notRenderInFps)
            {
                notRendered.layer = LayerMask.NameToLayer(invisibleLayerName);
                foreach (Transform child in notRendered.transform)
                {
                    child.gameObject.layer = LayerMask.NameToLayer(invisibleLayerName);
                }
            }
        }

        private void ShowInTPS()
        {
            playerReticle.SetActive(false);
            droneReticle.SetActive(true);
            foreach (GameObject notRendered in notRenderInFps)
            {
                notRendered.layer = 0;
                foreach (Transform child in notRendered.transform)
                {
                    child.gameObject.layer = 0;
                }
            }
        }
    }
}
