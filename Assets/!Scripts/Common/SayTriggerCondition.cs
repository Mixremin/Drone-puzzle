using _Config;
using Player;
using System.Collections;
using TMPro;
using UnityEngine;

namespace _Common
{
    [AddComponentMenu("Scripts/_Common/_Common.SayTriggerCondition")]
    internal class SayTriggerCondition : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI testText;

        [TextAreaAttribute]
        [SerializeField]
        private string testField;

        [SerializeField]
        private float holdTime = 3f;

        private static Coroutine showTextRoutine;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonMovement player) && SimpleInventory.instance.runnerPazzlePassed)
            {
                if (showTextRoutine == null)
                {
                    showTextRoutine = StartCoroutine(showText());
                    player.GetComponent<SwitchToDrone>().needToShowScreamer = true;
                }
                else
                {
                    StopCoroutine(showTextRoutine);

                    showTextRoutine = StartCoroutine(showText());
                }
            }
        }

        private IEnumerator showText()
        {
            testText.text = testField;
            GetComponent<Collider>().enabled = false;
            testText.enabled = true;
            yield return new WaitForSeconds(holdTime);
            testText.enabled = false;
        }
    }
}
