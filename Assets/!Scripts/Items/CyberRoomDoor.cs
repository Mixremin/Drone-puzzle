using _Config;
using System; 
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.Door")]
    internal class CyberRoomDoor : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private int newSceneNum;

        [SerializeField]
        private ShowTextInteraction needPhoneText;

        [SerializeField]
        private ShowTextInteraction needDroneText;

        public void Interact()
        {
            if (SimpleInventory.instance.hasDrone && SimpleInventory.instance.phoneUsed)
            {
                SceneManager.LoadScene(newSceneNum);
            } 
            else if (!SimpleInventory.instance.phoneUsed)
            {
                needPhoneText.Interact();
            } else if (!SimpleInventory.instance.hasDrone)
            {
                needDroneText.Interact();
            }


        }
    }
}
