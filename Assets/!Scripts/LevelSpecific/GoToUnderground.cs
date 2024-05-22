using _Config;
using _Items;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.GoToUnderground")]
    internal class GoToUnderground : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private int undergroundScene = 5;
        public void Interact()
        {
            if (SimpleInventory.instance.runnerPazzlePassed)
            {
                SceneManager.LoadScene(undergroundScene);
            }
        }
    }
}
