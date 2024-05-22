using _Config;
using _Items;
using UnityEngine;

namespace _Talkable
{
    [AddComponentMenu("Scripts/_Talkable/_Talkable.InformantNPC")]
    internal class InformantNPC : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TalkableNPC talkScript;

        private void Start()
        {
            if (SimpleInventory.instance.japanGamePassed)
            {
                Destroy(this);
            }
        }
        public void Interact()
        {
            talkScript.StartDialogue();
            SimpleInventory.instance.talkedToInformant = true;
            //Destroy(talkScript);
            Destroy(this);
        }
    }
}
