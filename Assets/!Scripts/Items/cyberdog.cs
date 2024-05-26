using _Talkable;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Items
{
    [AddComponentMenu("Scripts/_Items/_Items.cyberdog")]
    internal class cyberdog : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private TalkableNPC finalDialogue;
        public void Interact()
        {
            finalDialogue.StartDialogue();
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
