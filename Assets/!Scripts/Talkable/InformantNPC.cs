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

        public void Interact()
        {
            talkScript.StartDialogue();
            SimpleInventory.instance.talkedToInformant = true;
        }
    }
}
