using System.Collections;
using TMPro;
using UnityEngine;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.Phone")]
    internal class Phone : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TextMeshProUGUI itsPhoneText;

        [TextAreaAttribute]
        [SerializeField]
        private string interactedField;

        [SerializeField]
        private float holdTime = 3f;
        public void Interact()
        {
            _ = StartCoroutine(showText());
        }

        private IEnumerator showText()
        {
            itsPhoneText.text = interactedField;
            itsPhoneText.enabled = true;
            yield return new WaitForSeconds(holdTime);
            itsPhoneText.enabled = false;
        }
    }
}
