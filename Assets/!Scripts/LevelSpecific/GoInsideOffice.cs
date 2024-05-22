using _Config;
using _Items;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _LevelSpecific
{
    [AddComponentMenu("Scripts/_LevelSpecific/_LevelSpecific.GoInsideOffice")]
    internal class GoInsideOffice : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private int officeScene = 3;
        public void Interact()
        {
            if (SimpleInventory.instance.toOfficeCardObtained)
            {
                SceneManager.LoadScene(officeScene);
            }
        }
    }

}


