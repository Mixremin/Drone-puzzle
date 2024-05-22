using System.Collections;
using TMPro;
using UnityEngine;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.ShowTextInteraction")]
    internal class ShowTextInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TextMeshProUGUI testText;

        [TextAreaAttribute]
        [SerializeField]
        private string testField;

        [SerializeField]
        private float holdTime = 3f;

        private static Coroutine showTextRoutine;
        public void Interact()
        {
            if (showTextRoutine == null)
            {
                showTextRoutine = StartCoroutine(showText());
            }
            else
            {
                StopCoroutine(showTextRoutine);
                showTextRoutine = StartCoroutine(showText());
            }

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
