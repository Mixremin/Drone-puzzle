using _Config;
using _Items;
using UnityEngine;

namespace _Talkable
{
    [AddComponentMenu("Scripts/_Talkable/_Talkable.HackerNPC")]
    internal class HackerNPC : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TalkableNPC firstDialogue;

        [SerializeField]
        private TalkableNPC SecondDialogue;

        public void Interact()
        {
            if (SimpleInventory.instance.talkedToInformant && !SimpleInventory.instance.japanGamePassed && !SimpleInventory.instance.canStartJapanGame)
            {
                firstDialogue.StartDialogue();
                SimpleInventory.instance.canStartJapanGame = true;
                //Destroy(firstDialogue);
            }
            else if (SimpleInventory.instance.japanGamePassed)
            {
                SecondDialogue.StartDialogue();
                SimpleInventory.instance.hackerQuestPassed = true;
                //Destroy(SecondDialogue);
                Destroy(this);
            }

        }
    }
}
