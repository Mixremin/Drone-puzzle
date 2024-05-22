using _Config;
using Player;
using System.Collections;
using TMPro;
using UnityEngine;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.Drone")]
    internal class Drone : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private GameObject drone;

        [SerializeField]
        private SwitchToDrone switcher;

        [SerializeField]
        private GameObject view;

        [SerializeField]
        private TextMeshProUGUI testText;

        [TextAreaAttribute]
        [SerializeField]
        private string testField;

        [SerializeField]
        private float holdTime = 3f;

        public void Interact()
        {
            SimpleInventory.instance.hasDrone = true;

            _ = StartCoroutine(showText());
            drone.SetActive(true);
            switcher.enabled = true;
            view.SetActive(false);
        }

        private IEnumerator showText()
        {
            testText.text = testField;
            testText.enabled = true;
            yield return new WaitForSeconds(holdTime);
            testText.enabled = false;
            Destroy(gameObject);
        }

    }
}
