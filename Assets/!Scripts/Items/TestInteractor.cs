using System.Collections;
using TMPro;
using UnityEngine;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.TestInteractor")]
    internal class TestInteractor : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TextMeshProUGUI testText;

        [TextAreaAttribute]
        [SerializeField]
        private string testField;

        [SerializeField]
        private float holdTime = 3f;
        public void Interact()
        {
            _ = StartCoroutine(showText());
        }

        private IEnumerator showText()
        {
            testText.text = testField;
            testText.enabled = true;
            yield return new WaitForSeconds(holdTime);
            testText.enabled = false;
        }
    }
}
