using _Config;
using _Drone;
using _Horror;
using Config;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
namespace Player
{
    internal class SwitchToDrone : MonoBehaviour
    {
        [Header("Components")]
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

        [Header("Settings and UI")]
        [SerializeField]
        private float timeSlow = 3f;

        [SerializeField]
        private GameObject droneReticle;

        [SerializeField]
        private Volume glitchFX;

        [SerializeField]
        private GameObject playerReticle;

        [Header("Horror")]
        [SerializeField]
        private ShowScreamer showScreamer;

        public bool needToShowScreamer = false;

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
                if (!Locker.instance.LockedByMenu)
                {
                    if (!isDroning)
                    {
                        if (needToShowScreamer)
                        {
                            showScreamer.SpawnScreamer();
                            needToShowScreamer = false;
                        }
                        SwitchToDroning();
                    }
                    else
                    {
                        SwitchToFPS();
                    }
                }
            }
        }

        public void SwitchToDroning()
        {
            Time.timeScale = 1 / timeSlow;

            playerCam.SetActive(false);
            ShowInTPS();
            droneCam.SetActive(true);

            if (SimpleInventory.instance.runnerPazzlePassed)
            {
                glitchFX.profile.components[3].active = true;
            }

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

            if (SimpleInventory.instance.runnerPazzlePassed)
            {
                glitchFX.profile.components[3].active = true;
            }

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
