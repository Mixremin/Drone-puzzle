using _Items;
using TMPro;
using UnityEngine;

namespace _Player
{
    [AddComponentMenu("Scripts/_Player/_Player.Interaction")]
    internal class Interaction : MonoBehaviour
    {
        [SerializeField]
        private KeyCode interactionKey = KeyCode.E;

        [SerializeField]
        private float interactionRange = 10f;

        [SerializeField]
        private Camera playerCam;

        [SerializeField]
        private TextMeshProUGUI eText;

        private Vector3 rayOrigin;

        private void Update()
        {
            rayOrigin = playerCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(rayOrigin, playerCam.transform.forward * interactionRange, Color.red);
            eText.enabled = false;
            if (Physics.Raycast(rayOrigin, playerCam.transform.forward, out RaycastHit hit, interactionRange))
            {
                if (hit.transform.TryGetComponent(out IInteractable item))
                {
                    eText.enabled = true;
                    Debug.DrawRay(rayOrigin, playerCam.transform.forward * interactionRange, Color.green);
                    if (Input.GetKeyUp(interactionKey))
                    {
                        item.Interact();
                    }
                }
            }
        }
    }
}
