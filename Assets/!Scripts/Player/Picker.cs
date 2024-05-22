using _Items.PuckUps;
using Config;
using TMPro;
using UnityEngine;

namespace _Player
{
    [AddComponentMenu("Scripts/_Player/_Player.Picker")]
    internal class Picker : MonoBehaviour
    {
        [SerializeField]
        private KeyCode interactionKey = KeyCode.E;

        [SerializeField]
        private float interactionRange = 10f;

        [SerializeField]
        private Transform itemPlace;

        [SerializeField]
        private Transform viewParent;

        [SerializeField]
        private Camera playerCam;

        [SerializeField]
        private TextMeshProUGUI eText;

        private Vector3 rayOrigin;
        private GameObject pickedObject;

        private void Update()
        {
            if (!Locker.instance.InteractionLocked && pickedObject == null)
            {
                rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                eText.enabled = false;
                HandlePickUp();
            }
            //else if (pickedObject != null)
            //{
            //    if (Input.GetKeyUp(interactionKey))
            //    {
            //        Destroy(pickedObject);
            //    }
            //}
        }

        private void HandlePickUp()
        {

            if (Physics.Raycast(rayOrigin, playerCam.transform.forward, out RaycastHit hit, interactionRange))
            {
                if (hit.transform.TryGetComponent(out IPickable item))
                {
                    eText.enabled = true;
                    if (Input.GetKeyUp(interactionKey))
                    {
                        pickedObject = item.PickUp();
                        eText.enabled = false;
                        SetObjectToPlayer();
                    }
                }
            }
        }

        private void SetObjectToPlayer()
        {
            pickedObject.transform.SetParent(viewParent);
            pickedObject.transform.localPosition = Vector3.zero;
        }
    }
}
