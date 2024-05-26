using _Config;
using TMPro;
using UnityEngine;

namespace _UI
{
    [AddComponentMenu("Scripts/_UI/_UI.QuestChanger")]
    internal class QuestChanger : MonoBehaviour
    {
        [SerializeField]
        private string[] quests;

        [SerializeField]
        private TextMeshProUGUI questText;

        [SerializeField]
        private bool canChangeQuest = true;

        private void Start()
        {
            ChangeQuest();
        }

        private void OnEnable()
        {
            SimpleInventory.instance.questChanged += ChangeQuest;
        }

        private void ChangeQuest()
        {
            if (canChangeQuest)
            {
                if (!SimpleInventory.instance.hasDrone && !SimpleInventory.instance.phoneUsed)
                {
                    questText.text = quests[0];
                }
                else if (!SimpleInventory.instance.talkedToInformant)
                {
                    questText.text = quests[1];
                }
                else if (!SimpleInventory.instance.canStartJapanGame)
                {
                    questText.text = quests[2];
                }
                else if (!SimpleInventory.instance.japanGamePassed)
                {
                    questText.text = quests[3];
                }
                else if (!SimpleInventory.instance.hackerQuestPassed)
                {
                    questText.text = quests[4];
                }
                else if (!SimpleInventory.instance.toOfficeCardObtained)
                {
                    questText.text = quests[5];
                }
                else if (!SimpleInventory.instance.runnerPazzlePassed)
                {
                    questText.text = quests[6];
                }
            }
        }

        private void OnDisable()
        {
            SimpleInventory.instance.questChanged -= ChangeQuest;
        }
    }
}
