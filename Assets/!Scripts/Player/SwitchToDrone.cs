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
                    playerCam.SetActive(false);
                    ShowInTPS();
                    droneCam.SetActive(true);

                    Locker.instance.LockAll();
                    fpMovement.ResetVelocity();

                    isDroning = true;
                }
                else
                {
                    droneCam.SetActive(false);
                    HideInFPS();
                    playerCam.SetActive(true);

                    Locker.instance.UnlockAll();

                    isDroning = false;
                }

            }
        }

        private void HideInFPS()
        {
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
