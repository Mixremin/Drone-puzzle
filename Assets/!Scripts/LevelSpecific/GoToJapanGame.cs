using _Config;
using _Items;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.GoToJapanGame")]
    internal class GoToJapanGame : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private int japanGameScene = 2;

        [SerializeField]
        private ShowTextInteraction text;
        public void Interact()
        {
            if (SimpleInventory.instance.canStartJapanGame && !SimpleInventory.instance.japanGamePassed)
            {
                SceneManager.LoadScene(japanGameScene);
            }
            else
            {
                text.Interact();
            }
        }
    }
}
